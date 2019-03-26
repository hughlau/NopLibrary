using Microsoft.AspNetCore.Mvc;
using Nl.WebFramework.Components;

namespace Nop.Plugin.Payments.PayPalStandard.Components
{
    [ViewComponent(Name = "PaymentPayPalStandard")]
    public class PaymentPayPalStandardViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Payments.PayPalStandard/Views/PaymentInfo.cshtml");
        }
    }
}
