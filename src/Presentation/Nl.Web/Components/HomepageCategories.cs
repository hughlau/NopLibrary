using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class HomepageCategoriesViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public HomepageCategoriesViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PrepareHomepageCategoryModels();
            if (!model.Any())
                return Content("");

            return View(model);
        }
    }
}
