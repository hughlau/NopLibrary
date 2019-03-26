using FluentValidation;
using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.Core.Domain.Catalog;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductTagValidator : BaseNopValidator<ProductTagModel>
    {
        public ProductTagValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductTags.Fields.Name.Required"));

            SetDatabaseValidationRules<ProductTag>(dbContext);
        }
    }
}