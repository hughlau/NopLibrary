using FluentValidation;
using Nl.Web.Areas.Admin.Models.Common;
using Nl.Core.Domain.Common;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Common
{
    public partial class AddressAttributeValueValidator : BaseNopValidator<AddressAttributeValueModel>
    {
        public AddressAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttributeValue>(dbContext);
        }
    }
}