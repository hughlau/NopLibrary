using FluentValidation;
using Nl.Web.Areas.Admin.Models.Templates;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Templates
{
    public partial class ManufacturerTemplateValidator : BaseNopValidator<ManufacturerTemplateModel>
    {
        public ManufacturerTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.ViewPath.Required"));
        }
    }
}