using FluentValidation;
using Nl.Web.Areas.Admin.Models.Vendors;
using Nl.Core.Domain.Vendors;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Vendors
{
    public partial class VendorAttributeValidator : BaseNopValidator<VendorAttributeModel>
    {
        public VendorAttributeValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.VendorAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<VendorAttribute>(dbContext);
        }
    }
}