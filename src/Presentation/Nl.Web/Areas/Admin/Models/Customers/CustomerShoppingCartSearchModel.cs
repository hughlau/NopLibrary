using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer shopping cart search model
    /// </summary>
    public partial class CustomerShoppingCartSearchModel : BaseSearchModel
    {
        #region Ctor

        public CustomerShoppingCartSearchModel()
        {
            AvailableShoppingCartTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.ShoppingCartType.ShoppingCartType")]
        public int ShoppingCartTypeId { get; set; }

        public IList<SelectListItem> AvailableShoppingCartTypes { get; set; }

        #endregion
    }
}