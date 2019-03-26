using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class CustomerNavigationViewComponent : NopViewComponent
    {
        private readonly ICustomerModelFactory _customerModelFactory;

        public CustomerNavigationViewComponent(ICustomerModelFactory customerModelFactory)
        {
            _customerModelFactory = customerModelFactory;
        }

        public IViewComponentResult Invoke(int selectedTabId = 0)
        {
            var model = _customerModelFactory.PrepareCustomerNavigationModel(selectedTabId);
            return View(model);
        }
    }
}
