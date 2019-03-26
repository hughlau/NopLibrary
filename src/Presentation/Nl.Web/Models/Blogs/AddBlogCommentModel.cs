using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Blogs
{
    public partial class AddBlogCommentModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Blog.Comments.CommentText")]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}