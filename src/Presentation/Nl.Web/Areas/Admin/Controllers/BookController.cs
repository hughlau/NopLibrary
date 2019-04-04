using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nl.Core;
using Nl.Service.Library;
using Nl.Services.Localization;
using Nl.Services.Security;
using Nl.Services.Seo;
using Nl.Web.Areas.Admin.Factories.Library;
using Nl.Web.Areas.Admin.Models.Library.Book;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nl.Web.Areas.Admin.Controllers
{
    public class BookController : BaseAdminController
    {

        private readonly IBookModelFactory _bookModelFactory;
        private readonly IBookService _bookService;


        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;

        private readonly IPermissionService _permissionService;

        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;


        public BookController(
            IBookModelFactory bookModelFactory,
            IBookService bookService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            IPermissionService permissionService,
            IUrlRecordService urlRecordService,
            IWorkContext workContext)
        {
            _bookModelFactory = bookModelFactory;
            _bookService = bookService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _permissionService = permissionService;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = _bookModelFactory.PrepareBookSearchModel(new BookSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(BookSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCategories))
                return AccessDeniedKendoGridJson();

            //prepare model
            var model = _bookModelFactory.PrepareBookListModel(searchModel);

            return Json(model);
        }
    }
}
