using FluentValidation;
using Nl.Core.Domain.Catalog;
using Nl.Data;
using Nl.Services.Localization;
using Nl.Web.Areas.Admin.Models.Catalog;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Catalog
{
    /// <summary>
    /// Represent a review type validator
    /// </summary>
    public partial class ReviewTypeValidator : BaseNopValidator<ReviewTypeModel>
    {
        public ReviewTypeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Name.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Description.Required"));

            SetDatabaseValidationRules<ReviewType>(dbContext);
        }
    }
}
