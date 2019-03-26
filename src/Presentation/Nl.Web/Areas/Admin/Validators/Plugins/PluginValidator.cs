using FluentValidation;
using Nl.Web.Areas.Admin.Models.Plugins;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Plugins
{
    public partial class PluginValidator : BaseNopValidator<PluginModel>
    {
        public PluginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendlyName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Plugins.Fields.FriendlyName.Required"));
        }
    }
}