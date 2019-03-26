using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Security
{
    /// <summary>
    /// Represents a permission record model
    /// </summary>
    public partial class PermissionRecordModel : BaseNopModel
    {
        #region Properties

        public string Name { get; set; }

        public string SystemName { get; set; }

        #endregion
    }
}