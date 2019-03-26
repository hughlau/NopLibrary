using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a related product model
    /// </summary>
    public partial class RelatedProductModel : BaseNopEntityModel
    {
        #region Properties

        public int ProductId2 { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.RelatedProducts.Fields.Product")]
        public string Product2Name { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.RelatedProducts.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}