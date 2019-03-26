using FluentValidation;
using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.Core.Domain.Catalog;
using Nl.Data;
using Nl.Services.Localization;
using Nl.Services.Seo;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Catalog
{
    public partial class CategoryValidator : BaseNopValidator<CategoryModel>
    {
        public CategoryValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.Name.Required"));
            RuleFor(x => x.PageSizeOptions).Must(ValidatorUtilities.PageSizeOptionsValidator).WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.PageSizeOptions.ShouldHaveUniqueItems"));
            RuleFor(x => x.PageSize).Must((x, context) =>
            {
                if (!x.AllowCustomersToSelectPageSize && x.PageSize <= 0)
                    return false;

                return true;
            }).WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.PageSize.Positive"));
            RuleFor(x => x.SeName).Length(0, NopSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<Category>(dbContext);
        }
    }
}