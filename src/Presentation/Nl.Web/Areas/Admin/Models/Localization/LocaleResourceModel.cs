using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Localization;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Localization
{
    /// <summary>
    /// Represents a locale resource model
    /// </summary>
    [Validator(typeof(LanguageResourceValidator))]
    public partial class LocaleResourceModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Name")]
        public string ResourceName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Value")]
        public string ResourceValue { get; set; }

        public int LanguageId { get; set; }

        #endregion
    }
}