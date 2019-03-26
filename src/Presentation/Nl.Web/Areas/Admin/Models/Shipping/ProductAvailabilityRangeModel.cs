using System.Collections.Generic;
using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Shipping;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a product availability range model
    /// </summary>
    [Validator(typeof(ProductAvailabilityRangeValidator))]
    public partial class ProductAvailabilityRangeModel : BaseNopEntityModel, ILocalizedModel<ProductAvailabilityRangeLocalizedModel>
    {
        #region Ctor

        public ProductAvailabilityRangeModel()
        {
            Locales = new List<ProductAvailabilityRangeLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ProductAvailabilityRangeLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class ProductAvailabilityRangeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        public string Name { get; set; }
    }
}