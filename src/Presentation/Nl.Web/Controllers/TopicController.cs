﻿using Microsoft.AspNetCore.Mvc;
using Nl.Services.Localization;
using Nl.Services.Security;
using Nl.Services.Stores;
using Nl.Services.Topics;
using Nl.Web.Factories;
using Nl.WebFramework;
using Nl.WebFramework.Mvc.Filters;
using Nl.WebFramework.Security;

namespace Nl.Web.Controllers
{
    public partial class TopicController : BasePublicController
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly ITopicModelFactory _topicModelFactory;
        private readonly ITopicService _topicService;

        #endregion

        #region Ctor

        public TopicController(IAclService aclService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            IStoreMappingService storeMappingService,
            ITopicModelFactory topicModelFactory,
            ITopicService topicService)
        {
            _aclService = aclService;
            _localizationService = localizationService;
            _permissionService = permissionService;
            _storeMappingService = storeMappingService;
            _topicModelFactory = topicModelFactory;
            _topicService = topicService;
        }

        #endregion

        #region Methods

        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult TopicDetails(int topicId)
        {
            var model = _topicModelFactory.PrepareTopicModelById(topicId);
            var hasAdminAccess = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageTopics);
            //access to Topics preview
            if (model == null || (!model.Published && !hasAdminAccess))
                return RedirectToRoute("HomePage");
            
            //display "edit" (manage) link
            if (hasAdminAccess)
                DisplayEditLink(Url.Action("Edit", "Topic", new { id = model.Id, area = AreaNames.Admin }));

            //template
            var templateViewPath = _topicModelFactory.PrepareTemplateViewPath(model.TopicTemplateId);
            return View(templateViewPath, model);
        }

        public virtual IActionResult TopicDetailsPopup(string systemName)
        {
            var model = _topicModelFactory.PrepareTopicModelBySystemName(systemName);
            if (model == null)
                return RedirectToRoute("HomePage");

            ViewBag.IsPopup = true;

            //template
            var templateViewPath = _topicModelFactory.PrepareTemplateViewPath(model.TopicTemplateId);
            return PartialView(templateViewPath, model);
        }

        [HttpPost]
        [PublicAntiForgery]
        public virtual IActionResult Authenticate(int id, string password)
        {
            var authResult = false;
            var title = string.Empty;
            var body = string.Empty;
            var error = string.Empty;

            var topic = _topicService.GetTopicById(id);
            if (topic != null &&
                topic.Published &&
                //password protected?
                topic.IsPasswordProtected &&
                //store mapping
                _storeMappingService.Authorize(topic) &&
                //ACL (access control list)
                _aclService.Authorize(topic))
            {
                if (topic.Password != null && topic.Password.Equals(password))
                {
                    authResult = true;
                    title = _localizationService.GetLocalized(topic, x => x.Title);
                    body = _localizationService.GetLocalized(topic, x => x.Body);
                }
                else
                {
                    error = _localizationService.GetResource("Topic.WrongPassword");
                }
            }

            return Json(new { Authenticated = authResult, Title = title, Body = body, Error = error });
        }

        #endregion
    }
}