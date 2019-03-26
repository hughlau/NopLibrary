using FluentValidation;
using Nl.Web.Areas.Admin.Models.Polls;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Polls
{
    public partial class PollValidator : BaseNopValidator<PollModel>
    {
        public PollValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Fields.Name.Required"));
        }
    }
}