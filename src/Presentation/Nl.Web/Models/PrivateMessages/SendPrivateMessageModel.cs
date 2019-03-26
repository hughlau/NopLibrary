using FluentValidation.Attributes;
using Nl.WebFramework.Models;
using Nl.Web.Validators.PrivateMessages;

namespace Nl.Web.Models.PrivateMessages
{
    [Validator(typeof(SendPrivateMessageValidator))]
    public partial class SendPrivateMessageModel : BaseNopEntityModel
    {
        public int ToCustomerId { get; set; }
        public string CustomerToName { get; set; }
        public bool AllowViewingToProfile { get; set; }

        public int ReplyToMessageId { get; set; }
        
        public string Subject { get; set; }
        
        public string Message { get; set; }
    }
}