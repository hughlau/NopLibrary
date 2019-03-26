using System;
using Microsoft.AspNetCore.Mvc;
using Nl.Services.Customers;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class ProfileInfoViewComponent : NopViewComponent
    {
        private readonly ICustomerService _customerService;
        private readonly IProfileModelFactory _profileModelFactory;

        public ProfileInfoViewComponent(ICustomerService customerService, IProfileModelFactory profileModelFactory)
        {
            _customerService = customerService;
            _profileModelFactory = profileModelFactory;
        }

        public IViewComponentResult Invoke(int customerProfileId)
        {
            var customer = _customerService.GetCustomerById(customerProfileId);
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var model = _profileModelFactory.PrepareProfileInfoModel(customer);
            return View(model);
        }
    }
}
