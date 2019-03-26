using FluentValidation;
using Nl.Web.Areas.Admin.Models.Polls;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Polls
{
    public partial class PollAnswerValidator : BaseNopValidator<PollAnswerModel>
    {
        public PollAnswerValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Answers.Fields.Name.Required"));
        }
    }
}