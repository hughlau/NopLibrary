using FluentValidation;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Boards;

namespace Nl.Web.Validators.Boards
{
    public partial class EditForumPostValidator : BaseNopValidator<EditForumPostModel>
    {
        public EditForumPostValidator(ILocalizationService localizationService)
        {            
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}