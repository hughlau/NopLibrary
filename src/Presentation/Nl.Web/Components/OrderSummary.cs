using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Core;
using Nl.Core.Domain.Orders;
using Nl.Services.Orders;
using Nl.Web.Factories;
using Nl.WebFramework.Components;
using Nl.Web.Models.ShoppingCart;

namespace Nl.Web.Components
{
    public class OrderSummaryViewComponent : NopViewComponent
    {
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public OrderSummaryViewComponent(IShoppingCartModelFactory shoppingCartModelFactory,
            IShoppingCartService shoppingCartService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke(bool? prepareAndDisplayOrderReviewData, ShoppingCartModel overriddenModel)
        {
            //use already prepared (shared) model
            if (overriddenModel != null)
                return View(overriddenModel);

            //if not passed, then create a new model
            var cart = _shoppingCartService.GetShoppingCart(_workContext.CurrentCustomer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

            var model = new ShoppingCartModel();
            model = _shoppingCartModelFactory.PrepareShoppingCartModel(model, cart,
                isEditable: false,
                prepareAndDisplayOrderReviewData: prepareAndDisplayOrderReviewData.GetValueOrDefault());
            return View(model);
        }
    }
}
