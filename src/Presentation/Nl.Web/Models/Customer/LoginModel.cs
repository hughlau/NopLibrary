using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nl.Core.Domain.Customers;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;
using Nl.Web.Validators.Customer;

namespace Nl.Web.Models.Customer
{
    [Validator(typeof(LoginValidator))]
    public partial class LoginModel : BaseNopModel
    {
        public bool CheckoutAsGuest { get; set; }

        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Account.Login.Fields.Email")]
        public string Email { get; set; }

        public bool UsernamesEnabled { get; set; }

        public UserRegistrationType RegistrationType { get; set; }

        [NopResourceDisplayName("Account.Login.Fields.UserName")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [NoTrim]
        [NopResourceDisplayName("Account.Login.Fields.Password")]
        public string Password { get; set; }

        [NopResourceDisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}