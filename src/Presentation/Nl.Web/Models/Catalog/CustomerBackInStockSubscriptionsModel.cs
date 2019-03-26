using System.Collections.Generic;
using Nl.WebFramework.Models;
using Nl.Web.Models.Common;

namespace Nl.Web.Models.Catalog
{
    public partial class CustomerBackInStockSubscriptionsModel : BaseNopModel
    {
        public CustomerBackInStockSubscriptionsModel()
        {
            Subscriptions = new List<BackInStockSubscriptionModel>();
        }

        public IList<BackInStockSubscriptionModel> Subscriptions { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested classes

        public partial class BackInStockSubscriptionModel : BaseNopEntityModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string SeName { get; set; }
        }

        #endregion
    }
}