using FluentValidation.Attributes;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.Web.Validators.Customer;
using System.ComponentModel.DataAnnotations;

namespace Nl.Web.Models.Customer
{
    [Validator(typeof(GiftCardValidator))]
    public partial class CheckGiftCardBalanceModel : BaseNopModel
    {
        public string Result { get; set; }

        public string Message { get; set; }
        
        [NopResourceDisplayName("ShoppingCart.GiftCardCouponCode.Tooltip")]
        public string GiftCardCode { get; set; }
    }
}
