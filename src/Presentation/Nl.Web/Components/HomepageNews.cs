using Microsoft.AspNetCore.Mvc;
using Nl.Core.Domain.News;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class HomepageNewsViewComponent : NopViewComponent
    {
        private readonly INewsModelFactory _newsModelFactory;
        private readonly NewsSettings _newsSettings;

        public HomepageNewsViewComponent(INewsModelFactory newsModelFactory, NewsSettings newsSettings)
        {
            _newsModelFactory = newsModelFactory;
            _newsSettings = newsSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowNewsOnMainPage)
                return Content("");

            var model = _newsModelFactory.PrepareHomePageNewsItemsModel();
            return View(model);
        }
    }
}
