using FluentValidation;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Boards;

namespace Nl.Web.Validators.Boards
{
    public partial class EditForumTopicValidator : BaseNopValidator<EditForumTopicModel>
    {
        public EditForumTopicValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Forum.TopicSubjectCannotBeEmpty"));
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}