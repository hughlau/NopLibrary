using FluentValidation;
using Nl.Core.Domain.Gdpr;
using Nl.Data;
using Nl.Services.Localization;
using Nl.Web.Areas.Admin.Models.Settings;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Settings
{
    public partial class GdprConsentValidator : BaseNopValidator<GdprConsentModel>
    {
        public GdprConsentValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Gdpr.Consent.Message.Required"));
            RuleFor(x => x.RequiredMessage)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Gdpr.Consent.RequiredMessage.Required"))
                .When(x => x.IsRequired);

            SetDatabaseValidationRules<GdprConsent>(dbContext);
        }
    }
}