using System.Collections.Generic;
using Nl.Core.Domain.Catalog;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Customer
{
    public partial class CustomerAttributeModel : BaseNopEntityModel
    {
        public CustomerAttributeModel()
        {
            Values = new List<CustomerAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<CustomerAttributeValueModel> Values { get; set; }

    }

    public partial class CustomerAttributeValueModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}