using Nl.WebFramework.Models;

namespace Nl.Web.Models.Checkout
{
    public partial class CheckoutCompletedModel : BaseNopModel
    {
        public int OrderId { get; set; }
        public string CustomOrderNumber { get; set; }
        public bool OnePageCheckoutEnabled { get; set; }
    }
}