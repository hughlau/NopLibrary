using System;
using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Forums;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Forums
{
    /// <summary>
    /// Represents a forum group model
    /// </summary>
    [Validator(typeof(ForumGroupValidator))]
    public partial class ForumGroupModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}