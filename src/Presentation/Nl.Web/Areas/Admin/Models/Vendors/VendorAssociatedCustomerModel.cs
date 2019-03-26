using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor associated customer model
    /// </summary>
    public partial class VendorAssociatedCustomerModel : BaseNopEntityModel
    {
        #region Properties

        public string Email { get; set; }

        #endregion
    }
}