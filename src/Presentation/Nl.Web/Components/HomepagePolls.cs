﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nl.Web.Framework.Components;

namespace Nop.Web.Components
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