using System.Collections.Generic;
using Nl.Web.Framework.Models;
using Nop.Web.Models.Common;

namespace Nop.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel : BaseNopModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}