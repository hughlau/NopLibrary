using FluentValidation;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.PrivateMessages;

namespace Nl.Web.Validators.PrivateMessages
{
    public partial class SendPrivateMessageValidator : BaseNopValidator<SendPrivateMessageModel>
    {
        public SendPrivateMessageValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.SubjectCannotBeEmpty"));
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.MessageCannotBeEmpty"));
        }
    }
}