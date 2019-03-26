using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class AdminHeaderLinksViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public AdminHeaderLinksViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareAdminHeaderLinksModel();
            return View(model);
        }
    }
}
