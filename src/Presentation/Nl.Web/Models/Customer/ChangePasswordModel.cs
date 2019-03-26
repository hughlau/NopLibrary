using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;
using Nl.Web.Validators.Customer;

namespace Nl.Web.Models.Customer
{
    [Validator(typeof(ChangePasswordValidator))]
    public partial class ChangePasswordModel : BaseNopModel
    {
        [NoTrim]
        [DataType(DataType.Password)]
        [NopResourceDisplayName("Account.ChangePassword.Fields.OldPassword")]
        public string OldPassword { get; set; }

        [NoTrim]
        [DataType(DataType.Password)]
        [NopResourceDisplayName("Account.ChangePassword.Fields.NewPassword")]
        public string NewPassword { get; set; }

        [NoTrim]
        [DataType(DataType.Password)]
        [NopResourceDisplayName("Account.ChangePassword.Fields.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public string Result { get; set; }
    }
}