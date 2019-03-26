using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;
using Nl.Web.Validators.Vendors;

namespace Nl.Web.Models.Vendors
{
    [Validator(typeof(VendorInfoValidator))]
    public class VendorInfoModel : BaseNopModel
    {
        public VendorInfoModel()
        {
            VendorAttributes = new List<VendorAttributeModel>();
        }

        [NopResourceDisplayName("Account.VendorInfo.Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Account.VendorInfo.Email")]
        public string Email { get; set; }

        [NopResourceDisplayName("Account.VendorInfo.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Account.VendorInfo.Picture")]
        public string PictureUrl { get; set; }

        public IList<VendorAttributeModel> VendorAttributes { get; set; }
    }
}