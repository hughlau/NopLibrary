﻿using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Common
{
    public partial class SystemWarningModel : BaseNopModel
    {
        public SystemWarningLevel Level { get; set; }

        public string Text { get; set; }

        public bool DontEncode { get; set; }
    }

    public enum SystemWarningLevel
    {
        Pass,
        Recommendation,
        CopyrightRemovalKey,
        Warning,
        Fail
    }
}