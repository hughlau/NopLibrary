using System;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an order note model
    /// </summary>
    public partial class OrderNoteModel : BaseNopEntityModel
    {
        #region Properties

        public int OrderId { get; set; }

        [NopResourceDisplayName("Admin.Orders.OrderNotes.Fields.DisplayToCustomer")]
        public bool DisplayToCustomer { get; set; }

        [NopResourceDisplayName("Admin.Orders.OrderNotes.Fields.Note")]
        public string Note { get; set; }

        [NopResourceDisplayName("Admin.Orders.OrderNotes.Fields.Download")]
        public int DownloadId { get; set; }

        [NopResourceDisplayName("Admin.Orders.OrderNotes.Fields.Download")]
        public Guid DownloadGuid { get; set; }

        [NopResourceDisplayName("Admin.Orders.OrderNotes.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}