using System.Collections.Generic;
using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Vendors;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor attribute value model
    /// </summary>
    [Validator(typeof(VendorAttributeValueValidator))]
    public partial class VendorAttributeValueModel : BaseNopEntityModel, ILocalizedModel<VendorAttributeValueLocalizedModel>
    {
        #region Ctor

        public VendorAttributeValueModel()
        {
            Locales = new List<VendorAttributeValueLocalizedModel>();
        }

        #endregion

        #region Properties

        public int VendorAttributeId { get; set; }

        [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<VendorAttributeValueLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class VendorAttributeValueLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.Name")]
        public string Name { get; set; }
    }
}