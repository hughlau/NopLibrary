﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a category search model
    /// </summary>
    public partial class CategorySearchModel : BaseSearchModel
    {
        #region Ctor

        public CategorySearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Catalog.Categories.List.SearchCategoryName")]
        public string SearchCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Categories.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}