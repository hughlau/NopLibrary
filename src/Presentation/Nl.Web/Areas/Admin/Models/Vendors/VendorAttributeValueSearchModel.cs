﻿using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor attribute value search model
    /// </summary>
    public partial class VendorAttributeValueSearchModel : BaseSearchModel
    {
        #region Properties

        public int VendorAttributeId { get; set; }

        #endregion
    }
}