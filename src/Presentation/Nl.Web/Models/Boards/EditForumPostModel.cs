using FluentValidation.Attributes;
using Nl.Core.Domain.Forums;
using Nl.WebFramework.Models;
using Nl.Web.Validators.Boards;

namespace Nl.Web.Models.Boards
{
    [Validator(typeof(EditForumPostValidator))]
    public partial class EditForumPostModel : BaseNopModel
    {
        public int Id { get; set; }
        public int ForumTopicId { get; set; }

        public bool IsEdit { get; set; }

        public string Text { get; set; }
        public EditorType ForumEditor { get; set; }

        public string ForumName { get; set; }
        public string ForumTopicSubject { get; set; }
        public string ForumTopicSeName { get; set; }

        public bool IsCustomerAllowedToSubscribe { get; set; }
        public bool Subscribed { get; set; }
    }
}