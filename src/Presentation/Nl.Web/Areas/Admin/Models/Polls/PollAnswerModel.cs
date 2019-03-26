using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Polls;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Polls
{
    /// <summary>
    /// Represents a poll answer model
    /// </summary>
    [Validator(typeof(PollAnswerValidator))]
    public partial class PollAnswerModel : BaseNopEntityModel
    {
        #region Properties

        public int PollId { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.NumberOfVotes")]
        public int NumberOfVotes { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}