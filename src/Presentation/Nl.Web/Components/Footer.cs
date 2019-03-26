using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class FooterViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public FooterViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareFooterModel();
            return View(model);
        }
    }
}
