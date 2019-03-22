﻿using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Nl.Web.Framework.Mvc.ModelBinding;
using Nl.Web.Framework.Models;
using Nop.Web.Validators.Common;

namespace Nop.Web.Models.Common
{
    [Validator(typeof(ContactVendorValidator))]
    public partial class ContactVendorModel : BaseNopModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }

        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("ContactVendor.Email")]
        public string Email { get; set; }

        [NopResourceDisplayName("ContactVendor.Subject")]
        public string Subject { get; set; }
        public bool SubjectEnabled { get; set; }

        [NopResourceDisplayName("ContactVendor.Enquiry")]
        public string Enquiry { get; set; }

        [NopResourceDisplayName("ContactVendor.FullName")]
        public string FullName { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}