using FluentValidation;
using Nl.Web.Areas.Admin.Models.Topics;
using Nl.Core.Domain.Topics;
using Nl.Data;
using Nl.Services.Localization;
using Nl.Services.Seo;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Topics
{
    public partial class TopicValidator : BaseNopValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.SeName).Length(0, NopSeoDefaults.ForumTopicLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.ForumTopicLength));
            RuleFor(x => x.Title).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Admin.ContentManagement.Topics.Fields.Title.Required")));

            SetDatabaseValidationRules<Topic>(dbContext);
        }
    }
}
