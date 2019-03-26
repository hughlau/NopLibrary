using FluentValidation;
using Nl.Web.Areas.Admin.Models.Stores;
using Nl.Core.Domain.Stores;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Stores
{
    public partial class StoreValidator : BaseNopValidator<StoreModel>
    {
        public StoreValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Name.Required"));
            RuleFor(x => x.Url).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Url.Required"));

            SetDatabaseValidationRules<Store>(dbContext);
        }
    }
}