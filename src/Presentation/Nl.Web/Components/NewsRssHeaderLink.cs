using Microsoft.AspNetCore.Mvc;
using Nl.Core.Domain.News;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class NewsRssHeaderLinkViewComponent : NopViewComponent
    {
        private readonly NewsSettings _newsSettings;

        public NewsRssHeaderLinkViewComponent(NewsSettings newsSettings)
        {
            _newsSettings = newsSettings;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowHeaderRssUrl)
                return Content("");

            return View();
        }
    }
}
