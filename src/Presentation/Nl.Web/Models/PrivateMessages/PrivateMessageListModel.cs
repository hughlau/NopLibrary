using System.Collections.Generic;
using Nl.WebFramework.Models;
using Nl.Web.Models.Common;

namespace Nl.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel : BaseNopModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}