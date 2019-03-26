using System.ComponentModel.DataAnnotations;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an upload license model
    /// </summary>
    public partial class UploadLicenseModel : BaseNopModel
    {
        #region Properties

        public int OrderId { get; set; }

        public int OrderItemId { get; set; }

        [UIHint("Download")]
        public int LicenseDownloadId { get; set; }

        #endregion
    }
}