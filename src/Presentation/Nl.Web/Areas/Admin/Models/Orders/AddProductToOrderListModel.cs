using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a product list model to add to the order
    /// </summary>
    public partial class AddProductToOrderListModel : BasePagedListModel<ProductModel>
    {
    }
}