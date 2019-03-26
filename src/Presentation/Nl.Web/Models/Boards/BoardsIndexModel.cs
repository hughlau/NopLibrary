using System.Collections.Generic;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Boards
{
    public partial class BoardsIndexModel : BaseNopModel
    {
        public BoardsIndexModel()
        {
            ForumGroups = new List<ForumGroupModel>();
        }
        
        public IList<ForumGroupModel> ForumGroups { get; set; }
    }
}