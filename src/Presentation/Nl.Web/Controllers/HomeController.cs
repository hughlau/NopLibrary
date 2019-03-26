using Microsoft.AspNetCore.Mvc;
using Nl.WebFramework.Mvc.Filters;
using Nl.WebFramework.Security;

namespace Nl.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}