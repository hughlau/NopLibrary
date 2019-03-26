using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Templates;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a topic template model
    /// </summary>
    [Validator(typeof(TopicTemplateValidator))]
    public partial class TopicTemplateModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.System.Templates.Topic.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Topic.ViewPath")]
        public string ViewPath { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Topic.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}