using FluentValidation;
using Nl.Web.Areas.Admin.Models.Localization;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Localization
{
    public partial class LanguageResourceValidator : BaseNopValidator<LocaleResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ResourceName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Name.Required"));
            RuleFor(x => x.ResourceValue).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Value.Required"));
        }
    }
}