﻿using Nl.WebFramework.Models;

namespace Nl.Web.Models.Common
{
    public partial class LanguageModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string FlagImageFileName { get; set; }
    }
}