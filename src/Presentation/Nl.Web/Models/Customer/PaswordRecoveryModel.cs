using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;
using Nl.Web.Validators.Customer;

namespace Nl.Web.Models.Customer
{
    [Validator(typeof(PasswordRecoveryValidator))]
    public partial class PasswordRecoveryModel : BaseNopModel
    {
        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Account.PasswordRecovery.Email")]
        public string Email { get; set; }

        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}