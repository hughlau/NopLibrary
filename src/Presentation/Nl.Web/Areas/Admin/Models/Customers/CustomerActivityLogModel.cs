using System;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer activity log model
    /// </summary>
    public partial class CustomerActivityLogModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Customers.Customers.ActivityLog.ActivityLogType")]
        public string ActivityLogTypeName { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.ActivityLog.Comment")]
        public string Comment { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.ActivityLog.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.ActivityLog.IpAddress")]
        public string IpAddress { get; set; }

        #endregion
    }
}