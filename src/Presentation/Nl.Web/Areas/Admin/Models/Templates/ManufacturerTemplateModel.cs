using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Templates;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a manufacturer template model
    /// </summary>
    [Validator(typeof(ManufacturerTemplateValidator))]
    public partial class ManufacturerTemplateModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.System.Templates.Manufacturer.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Manufacturer.ViewPath")]
        public string ViewPath { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Manufacturer.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}