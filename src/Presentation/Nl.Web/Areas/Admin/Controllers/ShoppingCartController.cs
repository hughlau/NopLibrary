﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Core;
using Nl.Services.Catalog;
using Nl.Services.Customers;
using Nl.Services.Orders;
using Nl.Services.Security;
using Nl.Web.Areas.Admin.Factories;
using Nl.Web.Areas.Admin.Models.ShoppingCart;
using Nl.WebFramework.Mvc;

namespace Nl.Web.Areas.Admin.Controllers
{
    public partial class ShoppingCartController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWorkContext _workContext;
        #endregion

        #region Ctor

        public ShoppingCartController(ICustomerService customerService,
            IPermissionService permissionService,
            IProductService productService,
            IShoppingCartService shoppingCartService,
            IShoppingCartModelFactory shoppingCartModelFactory,
            IWorkContext workContext)
        {
            _customerService = customerService;
            _permissionService = permissionService;
            _productService = productService;
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
            _workContext = workContext;
        }

        #endregion
        
        #region Methods
        
        public virtual IActionResult CurrentCarts()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCurrentCarts))
                return AccessDeniedView();

            //prepare model
            var model = _shoppingCartModelFactory.PrepareShoppingCartSearchModel(new ShoppingCartSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult CurrentCarts(ShoppingCartSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCurrentCarts))
                return AccessDeniedKendoGridJson();

            //prepare model
            var model = _shoppingCartModelFactory.PrepareShoppingCartListModel(searchModel);

            return Json(model);
        }

        public virtual IActionResult ProductSearchAutoComplete(string term)
        {
            const int searchTermMinimumLength = 3;
            if (string.IsNullOrWhiteSpace(term) || term.Length < searchTermMinimumLength)
                return Content(string.Empty);

            //a vendor should have access only to his products
            var vendorId = 0;
            if (_workContext.CurrentVendor != null)
            {
                vendorId = _workContext.CurrentVendor.Id;
            }

            //products
            const int productNumber = 15;
            var products = _productService.SearchProducts(
                vendorId: vendorId,
                keywords: term,
                pageSize: productNumber,
                showHidden: true);

            var result = (from p in products
                select new
                {
                    label = p.Name,
                    productid = p.Id
                }).ToList();
            return Json(result);
        }

        [HttpPost]
        public virtual IActionResult GetCartDetails(ShoppingCartItemSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCurrentCarts))
                return AccessDeniedKendoGridJson();

            //try to get a customer with the specified id
            var customer = _customerService.GetCustomerById(searchModel.CustomerId)
                ?? throw new ArgumentException("No customer found with the specified id");

            //prepare model
            var model = _shoppingCartModelFactory.PrepareShoppingCartItemListModel(searchModel, customer);

            return Json(model);
        }
        
        [HttpPost]
        public virtual IActionResult DeleteItem(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCurrentCarts))
                return AccessDeniedKendoGridJson();
            
            _shoppingCartService.DeleteShoppingCartItem(id);

            return new NullJsonResult();
        }

        #endregion
    }
}