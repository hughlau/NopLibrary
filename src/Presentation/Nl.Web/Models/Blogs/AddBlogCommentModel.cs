using Nl.Web.Framework.Mvc.ModelBinding;
using Nl.Web.Framework.Models;

namespace Nop.Web.Models.Blogs
{
    public partial class AddBlogCommentModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Blog.Comments.CommentText")]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}