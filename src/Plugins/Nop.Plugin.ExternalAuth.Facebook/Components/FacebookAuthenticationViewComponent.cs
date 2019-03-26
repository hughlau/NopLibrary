using Microsoft.AspNetCore.Mvc;
using Nl.WebFramework.Components;

namespace Nop.Plugin.ExternalAuth.Facebook.Components
{
    [ViewComponent(Name = FacebookAuthenticationDefaults.ViewComponentName)]
    public class FacebookAuthenticationViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/ExternalAuth.Facebook/Views/PublicInfo.cshtml");
        }
    }
}