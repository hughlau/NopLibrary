﻿using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a recurring payment history search model
    /// </summary>
    public partial class RecurringPaymentHistorySearchModel : BaseSearchModel
    {
        #region Properties

        public int RecurringPaymentId { get; set; }

        #endregion
    }
}