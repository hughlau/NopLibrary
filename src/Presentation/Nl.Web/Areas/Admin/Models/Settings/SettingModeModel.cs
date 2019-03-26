using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a setting mode model
    /// </summary>
    public partial class SettingModeModel : BaseNopModel
    {
        #region Properties

        public string ModeName { get; set; }

        public bool Enabled { get; set; }

        #endregion
    }
}