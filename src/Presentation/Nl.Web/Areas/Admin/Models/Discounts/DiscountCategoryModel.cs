﻿using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount category model
    /// </summary>
    public partial class DiscountCategoryModel : BaseNopEntityModel
    {
        #region Properties

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        #endregion
    }
}