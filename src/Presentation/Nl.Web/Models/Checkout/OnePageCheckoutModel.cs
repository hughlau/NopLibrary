using Nl.WebFramework.Models;

namespace Nl.Web.Models.Checkout
{
    public partial class OnePageCheckoutModel : BaseNopModel
    {
        public bool ShippingRequired { get; set; }
        public bool DisableBillingAddressCheckoutStep { get; set; }

        public CheckoutBillingAddressModel BillingAddress { get; set; }
    }
}