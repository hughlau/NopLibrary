using FluentValidation;
using Nl.Web.Areas.Admin.Models.Vendors;
using Nl.Core.Domain.Vendors;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Vendors
{
    public partial class VendorAttributeValueValidator : BaseNopValidator<VendorAttributeValueModel>
    {
        public VendorAttributeValueValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.VendorAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<VendorAttributeValue>(dbContext);
        }
    }
}