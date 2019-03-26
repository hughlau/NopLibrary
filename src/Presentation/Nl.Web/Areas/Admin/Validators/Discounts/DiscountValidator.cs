using FluentValidation;
using Nl.Web.Areas.Admin.Models.Discounts;
using Nl.Core.Domain.Discounts;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Discounts
{
    public partial class DiscountValidator : BaseNopValidator<DiscountModel>
    {
        public DiscountValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Discounts.Fields.Name.Required"));

            SetDatabaseValidationRules<Discount>(dbContext);
        }
    }
}