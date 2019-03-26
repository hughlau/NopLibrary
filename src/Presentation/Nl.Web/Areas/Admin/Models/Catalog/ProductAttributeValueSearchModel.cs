using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product attribute value search model
    /// </summary>
    public partial class ProductAttributeValueSearchModel : BaseSearchModel
    {
        #region Properties

        public int ProductAttributeMappingId { get; set; }

        #endregion
    }
}