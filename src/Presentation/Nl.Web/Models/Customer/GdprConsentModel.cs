﻿using Nl.WebFramework.Models;

namespace Nl.Web.Models.Customer
{
    public partial class GdprConsentModel : BaseNopEntityModel
    {
        public string Message { get; set; }

        public bool IsRequired { get; set; }

        public string RequiredMessage { get; set; }

        public bool Accepted { get; set; }
    }
}