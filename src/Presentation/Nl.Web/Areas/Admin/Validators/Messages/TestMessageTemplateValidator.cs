using FluentValidation;
using Nl.Web.Areas.Admin.Models.Messages;
using Nl.Services.Localization;
using Nl.WebFramework.Validators;

namespace Nl.Web.Areas.Admin.Validators.Messages
{
    public partial class TestMessageTemplateValidator : BaseNopValidator<TestMessageTemplateModel>
    {
        public TestMessageTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SendTo).NotEmpty();
            RuleFor(x => x.SendTo).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
        }
    }
}