using FluentValidation;
using Nl.Web.Areas.Admin.Models.Messages;
using Nl.Core.Domain.Messages;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Messages
{
    public partial class EmailAccountValidator : BaseNopValidator<EmailAccountModel>
    {
        public EmailAccountValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
            
            RuleFor(x => x.DisplayName).NotEmpty();

            SetDatabaseValidationRules<EmailAccount>(dbContext);
        }
    }
}