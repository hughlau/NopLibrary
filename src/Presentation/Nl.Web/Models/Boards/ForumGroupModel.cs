﻿using System.Collections.Generic;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Boards
{
    public partial  class ForumGroupModel : BaseNopModel
    {
        public ForumGroupModel()
        {
            Forums = new List<ForumRowModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }

        public IList<ForumRowModel> Forums { get; set; }
    }
}