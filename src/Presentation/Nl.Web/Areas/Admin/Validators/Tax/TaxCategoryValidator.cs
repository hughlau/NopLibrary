using FluentValidation;
using Nl.Web.Areas.Admin.Models.Tax;
using Nl.Core.Domain.Tax;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Tax
{
    public partial class TaxCategoryValidator : BaseNopValidator<TaxCategoryModel>
    {
        public TaxCategoryValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Tax.Categories.Fields.Name.Required"));

            SetDatabaseValidationRules<TaxCategory>(dbContext);
        }
    }
}