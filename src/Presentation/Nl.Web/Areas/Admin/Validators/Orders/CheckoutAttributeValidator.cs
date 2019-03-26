using FluentValidation;
using Nl.Web.Areas.Admin.Models.Orders;
using Nl.Core.Domain.Orders;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Orders
{
    public partial class CheckoutAttributeValidator : BaseNopValidator<CheckoutAttributeModel>
    {
        public CheckoutAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<CheckoutAttribute>(dbContext);
        }
    }
}