using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class PopularProductTagsViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public PopularProductTagsViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PreparePopularProductTagsModel();

            if (!model.Tags.Any())
                return Content("");

            return View(model);
        }
    }
}
