using Microsoft.AspNetCore.Mvc;
using Nl.Core.Domain.Blogs;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class BlogTagsViewComponent : NopViewComponent
    {
        private readonly BlogSettings _blogSettings;
        private readonly IBlogModelFactory _blogModelFactory;

        public BlogTagsViewComponent(BlogSettings blogSettings, IBlogModelFactory blogModelFactory)
        {
            _blogSettings = blogSettings;
            _blogModelFactory = blogModelFactory;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_blogSettings.Enabled)
                return Content("");

            var model = _blogModelFactory.PrepareBlogPostTagListModel();
            return View(model);
        }
    }
}
