using FluentValidation;
using Nl.Web.Areas.Admin.Models.Forums;
using Nl.Core.Domain.Forums;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Forums
{
    public partial class ForumValidator : BaseNopValidator<ForumModel>
    {
        public ForumValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.Name.Required"));
            RuleFor(x => x.ForumGroupId).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId.Required"));

            SetDatabaseValidationRules<Forum>(dbContext);
        }
    }
}