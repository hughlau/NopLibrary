﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.Web.Framework.Mvc.ModelBinding;
using Nl.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Topics
{
    /// <summary>
    /// Represents a topic search model
    /// </summary>
    public partial class TopicSearchModel : BaseSearchModel
    {
        #region Ctor

        public TopicSearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Topics.List.SearchStore")]
        public int SearchStoreId { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Topics.List.SearchKeywords")]
        public string SearchKeywords { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}