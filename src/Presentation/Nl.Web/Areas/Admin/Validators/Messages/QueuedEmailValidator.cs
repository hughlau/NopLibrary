using FluentValidation;
using Nl.Web.Areas.Admin.Models.Messages;
using Nl.Core.Domain.Messages;
using Nl.Data;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Messages
{
    public partial class QueuedEmailValidator : BaseNopValidator<QueuedEmailModel>
    {
        public QueuedEmailValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.From).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.From.Required"));
            RuleFor(x => x.To).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.To.Required"));

            RuleFor(x => x.SentTries).NotNull().WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.SentTries.Required"))
                                    .InclusiveBetween(0, 99999).WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.SentTries.Range"));

            SetDatabaseValidationRules<QueuedEmail>(dbContext);

        }
    }
}