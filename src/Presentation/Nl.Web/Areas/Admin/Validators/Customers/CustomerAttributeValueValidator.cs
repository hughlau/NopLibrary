using FluentValidation;
using Nl.Web.Areas.Admin.Models.Customers;
using Nl.Core.Domain.Customers;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Customers
{
    public partial class CustomerAttributeValueValidator : BaseNopValidator<CustomerAttributeValueModel>
    {
        public CustomerAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerAttributeValue>(dbContext);
        }
    }
}