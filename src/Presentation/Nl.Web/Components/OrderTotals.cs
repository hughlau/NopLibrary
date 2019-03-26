using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nl.Core;
using Nl.Core.Domain.Orders;
using Nl.Services.Orders;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class OrderTotalsViewComponent : NopViewComponent
    {
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public OrderTotalsViewComponent(IShoppingCartModelFactory shoppingCartModelFactory,
            IShoppingCartService shoppingCartService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke(bool isEditable)
        {
            var cart = _shoppingCartService.GetShoppingCart(_workContext.CurrentCustomer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

            var model = _shoppingCartModelFactory.PrepareOrderTotalsModel(cart, isEditable);
            return View(model);
        }
    }
}
