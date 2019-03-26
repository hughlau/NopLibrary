using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Logging
{
    /// <summary>
    /// Represents an activity log type model
    /// </summary>
    public partial class ActivityLogTypeModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLogType.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.ActivityLog.ActivityLogType.Fields.Enabled")]
        public bool Enabled { get; set; }

        #endregion
    }
}