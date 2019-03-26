using Microsoft.AspNetCore.Mvc;
using Nl.Services.Security;
using Nl.Web.Areas.Admin.Factories;
using Nl.Web.Areas.Admin.Models.Customers;

namespace Nl.Web.Areas.Admin.Controllers
{
    public partial class OnlineCustomerController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public OnlineCustomerController(ICustomerModelFactory customerModelFactory,
            IPermissionService permissionService)
        {
            _customerModelFactory = customerModelFactory;
            _permissionService = permissionService;
        }

        #endregion
        
        #region Methods

        public virtual IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCustomers))
                return AccessDeniedView();

            //prepare model
            var model = _customerModelFactory.PrepareOnlineCustomerSearchModel(new OnlineCustomerSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(OnlineCustomerSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCustomers))
                return AccessDeniedKendoGridJson();

            //prepare model
            var model = _customerModelFactory.PrepareOnlineCustomerListModel(searchModel);

            return Json(model);
        }

        #endregion
    }
}