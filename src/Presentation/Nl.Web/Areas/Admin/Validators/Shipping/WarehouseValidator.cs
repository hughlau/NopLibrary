using FluentValidation;
using Nl.Web.Areas.Admin.Models.Shipping;
using Nl.Core.Domain.Shipping;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Shipping
{
    public partial class WarehouseValidator : BaseNopValidator<WarehouseModel>
    {
        public WarehouseValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Warehouses.Fields.Name.Required"));

            SetDatabaseValidationRules<Warehouse>(dbContext);
        }
    }
}