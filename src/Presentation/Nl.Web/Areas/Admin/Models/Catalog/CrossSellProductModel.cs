using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a cross-sell product model
    /// </summary>
    public partial class CrossSellProductModel : BaseNopEntityModel
    {
        #region Properties

        public int ProductId2 { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.CrossSells.Fields.Product")]
        public string Product2Name { get; set; }

        #endregion
    }
}