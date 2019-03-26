using FluentValidation;
using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.Core.Domain.Catalog;
using Nl.Data;
using Nl.Services.Localization;
using Nl.Services.Seo;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductValidator : BaseNopValidator<ProductModel>
    {
        public ProductValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Products.Fields.Name.Required"));
            RuleFor(x => x.SeName).Length(0, NopSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<Product>(dbContext);
        }
    }
}