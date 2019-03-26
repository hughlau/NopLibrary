using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Templates;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a category template model
    /// </summary>
    [Validator(typeof(CategoryTemplateValidator))]
    public partial class CategoryTemplateModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.System.Templates.Category.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Category.ViewPath")]
        public string ViewPath { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Category.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}