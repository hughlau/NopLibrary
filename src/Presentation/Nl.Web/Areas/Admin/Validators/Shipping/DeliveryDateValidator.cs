using FluentValidation;
using Nl.Web.Areas.Admin.Models.Shipping;
using Nl.Core.Domain.Shipping;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Shipping
{
    public partial class DeliveryDateValidator : BaseNopValidator<DeliveryDateModel>
    {
        public DeliveryDateValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.DeliveryDates.Fields.Name.Required"));

            SetDatabaseValidationRules<DeliveryDate>(dbContext);
        }
    }
}