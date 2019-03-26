using FluentValidation;
using Nl.Web.Areas.Admin.Models.Orders;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Orders
{
    public partial class ReturnRequestActionValidator : BaseNopValidator<ReturnRequestActionModel>
    {
        public ReturnRequestActionValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Order.ReturnRequestActions.Name.Required"));
        }
    }
}