using FluentValidation;
using Nl.Core.Domain.Common;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Common;

namespace Nl.Web.Validators.Common
{
    public partial class ContactUsValidator : BaseNopValidator<ContactUsModel>
    {
        public ContactUsValidator(ILocalizationService localizationService, CommonSettings commonSettings)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            RuleFor(x => x.FullName).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.FullName.Required"));
            if (commonSettings.SubjectFieldOnContactUsForm)
            {
                RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Subject.Required"));
            }
            RuleFor(x => x.Enquiry).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Enquiry.Required"));
        }
    }
}