using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class HomepagePollsViewComponent : NopViewComponent
    {
        private readonly IPollModelFactory _pollModelFactory;

        public HomepagePollsViewComponent(IPollModelFactory pollModelFactory)
        {
            _pollModelFactory = pollModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _pollModelFactory.PrepareHomePagePollModels();
            if (!model.Any())
                return Content("");

            return View(model);
        }
    }
}
