using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;
using Nl.Web.Validators.ShoppingCart;

namespace Nl.Web.Models.ShoppingCart
{
    [Validator(typeof(WishlistEmailAFriendValidator))]
    public partial class WishlistEmailAFriendModel : BaseNopModel
    {
        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Wishlist.EmailAFriend.FriendEmail")]
        public string FriendEmail { get; set; }
        
        [NopResourceDisplayName("Wishlist.EmailAFriend.YourEmailAddress")]
        public string YourEmailAddress { get; set; }
        
        [NopResourceDisplayName("Wishlist.EmailAFriend.PersonalMessage")]
        public string PersonalMessage { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}