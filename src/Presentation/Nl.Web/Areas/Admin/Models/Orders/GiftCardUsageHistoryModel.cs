using System;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a gift card usage history model
    /// </summary>
    public partial class GiftCardUsageHistoryModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.GiftCards.History.UsedValue")]
        public string UsedValue { get; set; }

        public int OrderId { get; set; }

        [NopResourceDisplayName("Admin.GiftCards.History.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [NopResourceDisplayName("Admin.GiftCards.History.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        #endregion
    }
}