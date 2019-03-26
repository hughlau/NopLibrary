using FluentValidation;
using Nl.Web.Areas.Admin.Models.Directory;
using Nl.Core.Domain.Directory;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Directory
{
    public partial class MeasureDimensionValidator : BaseNopValidator<MeasureDimensionModel>
    {
        public MeasureDimensionValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Name.Required"));
            RuleFor(x => x.SystemKeyword).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Dimensions.Fields.SystemKeyword.Required"));

            SetDatabaseValidationRules<MeasureDimension>(dbContext);
        }
    }
}