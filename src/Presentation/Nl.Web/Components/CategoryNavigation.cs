using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class CategoryNavigationViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public CategoryNavigationViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            var model = _catalogModelFactory.PrepareCategoryNavigationModel(currentCategoryId, currentProductId);
            return View(model);
        }
    }
}
