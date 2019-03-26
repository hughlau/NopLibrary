﻿using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount manufacturer model
    /// </summary>
    public partial class DiscountManufacturerModel : BaseNopEntityModel
    {
        #region Properties

        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        #endregion
    }
}