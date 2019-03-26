using System;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor note model
    /// </summary>
    public partial class VendorNoteModel : BaseNopEntityModel
    {
        #region Properties

        public int VendorId { get; set; }

        [NopResourceDisplayName("Admin.Vendors.VendorNotes.Fields.Note")]
        public string Note { get; set; }

        [NopResourceDisplayName("Admin.Vendors.VendorNotes.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}