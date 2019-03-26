using System.ComponentModel.DataAnnotations;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Newsletter
{
    public partial class NewsletterBoxModel : BaseNopModel
    {
        [DataType(DataType.EmailAddress)]
        public string NewsletterEmail { get; set; }
        public bool AllowToUnsubscribe { get; set; }
    }
}