using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a related product search model
    /// </summary>
    public partial class RelatedProductSearchModel : BaseSearchModel
    {
        #region Properties

        public int ProductId { get; set; }

        #endregion
    }
}