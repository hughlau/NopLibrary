﻿using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Forums
{
    /// <summary>
    /// Represents a forum search model
    /// </summary>
    public partial class ForumSearchModel : BaseSearchModel
    {
        #region Properties

        public int ForumGroupId { get; set; }

        #endregion
    }
}