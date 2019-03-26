using FluentValidation;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Customer;

namespace Nl.Web.Validators.Customer
{
    public partial class PasswordRecoveryValidator : BaseNopValidator<PasswordRecoveryModel>
    {
        public PasswordRecoveryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}