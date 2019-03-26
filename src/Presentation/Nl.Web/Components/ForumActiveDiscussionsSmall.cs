using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class ForumActiveDiscussionsSmallViewComponent : NopViewComponent
    {
        private readonly IForumModelFactory _forumModelFactory;

        public ForumActiveDiscussionsSmallViewComponent(IForumModelFactory forumModelFactory)
        {
            _forumModelFactory = forumModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _forumModelFactory.PrepareActiveDiscussionsModel();
            if (!model.ForumTopics.Any())
                return Content("");

            return View(model);
        }
    }
}
