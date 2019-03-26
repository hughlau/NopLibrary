﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nl.Core.Domain.Payments;
using Nl.Services.Configuration;
using Nl.Services.Directory;
using Nl.Services.Events;
using Nl.Services.Localization;
using Nl.Services.Messages;
using Nl.Services.Payments;
using Nl.Services.Plugins;
using Nl.Services.Security;
using Nl.Web.Areas.Admin.Factories;
using Nl.Web.Areas.Admin.Models.Payments;
using Nl.WebFramework.Mvc;
using Nl.WebFramework.Mvc.Filters;

namespace Nl.Web.Areas.Admin.Controllers
{
    public partial class PaymentController : BaseAdminController
    {
        #region Fields

        private readonly ICountryService _countryService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPaymentModelFactory _paymentModelFactory;
        private readonly IPaymentService _paymentService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly PaymentSettings _paymentSettings;

        #endregion

        #region Ctor

        public PaymentController(ICountryService countryService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPaymentModelFactory paymentModelFactory,
            IPaymentService paymentService,
            IPermissionService permissionService,
            ISettingService settingService,
            PaymentSettings paymentSettings)
        {
            _countryService = countryService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _paymentModelFactory = paymentModelFactory;
            _paymentService = paymentService;
            _permissionService = permissionService;
            _settingService = settingService;
            _paymentSettings = paymentSettings;
        }

        #endregion

        #region Methods  
        
        public virtual IActionResult PaymentMethods()
        {
            return RedirectToAction("Methods");
        }

        public virtual IActionResult Methods()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            //prepare model
            var model = _paymentModelFactory.PreparePaymentMethodsModel(new PaymentMethodsModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Methods(PaymentMethodSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedKendoGridJson();

            //prepare model
            var model = _paymentModelFactory.PreparePaymentMethodListModel(searchModel);

            return Json(model);
        }

        [HttpPost]
        public virtual IActionResult MethodUpdate(PaymentMethodModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            var pm = _paymentService.LoadPaymentMethodBySystemName(model.SystemName);
            if (_paymentService.IsPaymentMethodActive(pm))
            {
                if (!model.IsActive)
                {
                    //mark as disabled
                    _paymentSettings.ActivePaymentMethodSystemNames.Remove(pm.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_paymentSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    //mark as active
                    _paymentSettings.ActivePaymentMethodSystemNames.Add(pm.PluginDescriptor.SystemName);
                    _settingService.SaveSetting(_paymentSettings);
                }
            }

            var pluginDescriptor = pm.PluginDescriptor;
            pluginDescriptor.FriendlyName = model.FriendlyName;
            pluginDescriptor.DisplayOrder = model.DisplayOrder;

            //update the description file
            pluginDescriptor.Save();

            //raise event
            _eventPublisher.Publish(new PluginUpdatedEvent(pluginDescriptor));

            return new NullJsonResult();
        }

        public virtual IActionResult MethodRestrictions()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            //prepare model
            var model = _paymentModelFactory.PreparePaymentMethodsModel(new PaymentMethodsModel());

            return View(model);
        }

        //we ignore this filter for increase RequestFormLimits
        [AdminAntiForgery(true)]
        //we use 2048 value because in some cases default value (1024) is too small for this action
        [RequestFormLimits(ValueCountLimit = 2048)]
        [HttpPost, ActionName("MethodRestrictions")]
        public virtual IActionResult MethodRestrictionsSave(PaymentMethodsModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            var paymentMethods = _paymentService.LoadAllPaymentMethods();
            var countries = _countryService.GetAllCountries(showHidden: true);

            foreach (var pm in paymentMethods)
            {
                var formKey = "restrict_" + pm.PluginDescriptor.SystemName;
                var countryIdsToRestrict = (!StringValues.IsNullOrEmpty(model.Form[formKey])
                        ? model.Form[formKey].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                        : new List<string>())
                    .Select(x => Convert.ToInt32(x)).ToList();

                var newCountryIds = new List<int>();
                foreach (var c in countries)
                {
                    if (countryIdsToRestrict.Contains(c.Id))
                    {
                        newCountryIds.Add(c.Id);
                    }
                }

                _paymentService.SaveRestictedCountryIds(pm, newCountryIds);
            }

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Configuration.Payment.MethodRestrictions.Updated"));

            //selected tab
            SaveSelectedTabName();

            return RedirectToAction("MethodRestrictions");
        }

        #endregion
    }
}