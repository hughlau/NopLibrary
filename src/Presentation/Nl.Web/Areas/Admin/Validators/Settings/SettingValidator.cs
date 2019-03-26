using FluentValidation;
using Nl.Web.Areas.Admin.Models.Settings;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Settings
{
    public partial class SettingValidator : BaseNopValidator<SettingModel>
    {
        public SettingValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.AllSettings.Fields.Name.Required"));
        }
    }
}