﻿using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Validators.Directory;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a measure weight model
    /// </summary>
    [Validator(typeof(MeasureWeightValidator))]
    public partial class MeasureWeightModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.SystemKeyword")]
        public string SystemKeyword { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.Ratio")]
        public decimal Ratio { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.IsPrimaryWeight")]
        public bool IsPrimaryWeight { get; set; }

        #endregion
    }
}