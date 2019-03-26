using FluentValidation;
using Nl.Web.Areas.Admin.Models.Directory;
using Nl.Core.Domain.Directory;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Directory
{
    public partial class StateProvinceValidator : BaseNopValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));

            SetDatabaseValidationRules<StateProvince>(dbContext);
        }
    }
}