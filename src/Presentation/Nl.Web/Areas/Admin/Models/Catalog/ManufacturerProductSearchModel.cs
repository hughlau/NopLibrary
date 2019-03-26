using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a manufacturer product search model
    /// </summary>
    public partial class ManufacturerProductSearchModel : BaseSearchModel
    {
        #region Properties

        public int ManufacturerId { get; set; }

        #endregion
    }
}