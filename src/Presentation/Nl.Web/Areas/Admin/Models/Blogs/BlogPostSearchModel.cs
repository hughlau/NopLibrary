using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Blogs
{
    /// <summary>
    /// Represents a blog post search model
    /// </summary>
    public partial class BlogPostSearchModel : BaseSearchModel
    {
        #region Ctor

        public BlogPostSearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Blog.BlogPosts.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}