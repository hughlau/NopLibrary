using FluentValidation;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Vendors;

namespace Nl.Web.Validators.Vendors
{
    public partial class ApplyVendorValidator : BaseNopValidator<ApplyVendorModel>
    {
        public ApplyVendorValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Vendors.ApplyAccount.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Vendors.ApplyAccount.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}