using System.Collections.Generic;
using Nl.WebFramework.Models;
using Nl.Web.Models.Common;

namespace Nl.Web.Models.Profile
{
    public partial class ProfilePostsModel : BaseNopModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}