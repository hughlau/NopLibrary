using Microsoft.AspNetCore.Mvc;
using Nl.Core.Domain.Blogs;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class BlogMonthsViewComponent : NopViewComponent
    {
        private readonly BlogSettings _blogSettings;
        private readonly IBlogModelFactory _blogModelFactory;

        public BlogMonthsViewComponent(BlogSettings blogSettings, IBlogModelFactory blogModelFactory)
        {
            _blogSettings = blogSettings;
            _blogModelFactory = blogModelFactory;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_blogSettings.Enabled)
                return Content("");

            var model = _blogModelFactory.PrepareBlogPostYearModel();
            return View(model);
        }
    }
}
