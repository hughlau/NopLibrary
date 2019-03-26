using FluentValidation;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;
using Nl.Web.Models.Customer;

namespace Nl.Web.Validators.Customer
{
    public partial class GiftCardValidator : BaseNopValidator<CheckGiftCardBalanceModel>
    {
        public GiftCardValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.GiftCardCode).NotEmpty().WithMessage(localizationService.GetResource("CheckGiftCardBalance.GiftCardCouponCode.Empty"));            
        }
    }
}
