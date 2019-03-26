using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a model of products that use the specification attribute
    /// </summary>
    public partial class SpecificationAttributeProductModel : BaseNopEntityModel
    {
        #region Properties

        public int SpecificationAttributeId { get; set; }

        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts.Product")]
        public string ProductName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts.Published")]
        public bool Published { get; set; }

        #endregion
    }
}