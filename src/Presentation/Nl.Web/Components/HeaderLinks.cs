using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class HeaderLinksViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public HeaderLinksViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareHeaderLinksModel();
            return View(model);
        }
    }
}
