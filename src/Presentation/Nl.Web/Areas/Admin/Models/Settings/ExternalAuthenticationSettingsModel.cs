using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents an external authentication settings model
    /// </summary>
    public partial class ExternalAuthenticationSettingsModel : BaseNopModel, ISettingsModel
    {
        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AllowCustomersToRemoveAssociations")]
        public bool AllowCustomersToRemoveAssociations { get; set; }

        #endregion
    }
}