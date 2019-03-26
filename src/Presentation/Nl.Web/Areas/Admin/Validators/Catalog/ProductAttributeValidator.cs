using FluentValidation;
using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.Core.Domain.Catalog;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductAttributeValidator : BaseNopValidator<ProductAttributeModel>
    {
        public ProductAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.ProductAttributes.Fields.Name.Required"));
            SetDatabaseValidationRules<ProductAttribute>(dbContext);
        }
    }
}