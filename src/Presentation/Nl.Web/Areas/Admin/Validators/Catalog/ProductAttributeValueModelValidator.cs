using FluentValidation;
using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.Core.Domain.Catalog;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductAttributeValueModelValidator : BaseNopValidator<ProductAttributeValueModel>
    {
        public ProductAttributeValueModelValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Name.Required"));

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Quantity.GreaterThanOrEqualTo1"))
                .When(x => x.AttributeValueTypeId == (int)AttributeValueType.AssociatedToProduct && !x.CustomerEntersQty);

            RuleFor(x => x.AssociatedProductId)
                .GreaterThanOrEqualTo(1)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AssociatedProduct.Choose"))
                .When(x => x.AttributeValueTypeId == (int)AttributeValueType.AssociatedToProduct);

            SetDatabaseValidationRules<ProductAttributeValue>(dbContext);
        }
    }
}