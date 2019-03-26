using FluentValidation;
using Nl.Core.Domain.Customers;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Customer;

namespace Nl.Web.Validators.Customer
{
    public partial class ChangePasswordValidator : BaseNopValidator<ChangePasswordModel>
    {
        public ChangePasswordValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.OldPassword.Required"));
            RuleFor(x => x.NewPassword).IsPassword(localizationService, customerSettings);
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.ConfirmNewPassword.Required"));
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage(localizationService.GetResource("Account.ChangePassword.Fields.NewPassword.EnteredPasswordsDoNotMatch"));            
        }
    }
}