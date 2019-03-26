using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a manufacturer product model
    /// </summary>
    public partial class ManufacturerProductModel : BaseNopEntityModel
    {
        #region Properties

        public int ManufacturerId { get; set; }

        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.Product")]
        public string ProductName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.IsFeaturedProduct")]
        public bool IsFeaturedProduct { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}