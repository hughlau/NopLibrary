using FluentValidation;
using Nl.Web.Areas.Admin.Models.Common;
using Nl.Core.Domain.Common;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Common
{
    public partial class AddressAttributeValidator : BaseNopValidator<AddressAttributeModel>
    {
        public AddressAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttribute>(dbContext);
        }
    }
}