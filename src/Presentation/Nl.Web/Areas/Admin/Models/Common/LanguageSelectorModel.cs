using System.Collections.Generic;
using Nl.Web.Areas.Admin.Models.Localization;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an admin language selector model
    /// </summary>
    public partial class LanguageSelectorModel : BaseNopModel
    {
        #region Ctor

        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        #endregion

        #region Properties

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public LanguageModel CurrentLanguage { get; set; }

        #endregion
    }
}