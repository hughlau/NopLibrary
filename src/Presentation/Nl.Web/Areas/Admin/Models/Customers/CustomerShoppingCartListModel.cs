using Nl.Web.Areas.Admin.Models.ShoppingCart;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer shopping cart list model
    /// </summary>
    public partial class CustomerShoppingCartListModel : BasePagedListModel<ShoppingCartItemModel>
    {
    }
}