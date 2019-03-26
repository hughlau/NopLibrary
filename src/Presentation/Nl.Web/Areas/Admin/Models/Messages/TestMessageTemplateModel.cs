using System.Collections.Generic;
using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Messages;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Messages
{
    [Validator(typeof(TestMessageTemplateValidator))]
    public partial class TestMessageTemplateModel : BaseNopEntityModel
    {
        public TestMessageTemplateModel()
        {
            Tokens = new List<string>();
        }

        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.MessageTemplates.Test.Tokens")]
        public List<string> Tokens { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.MessageTemplates.Test.SendTo")]
        public string SendTo { get; set; }
    }
}