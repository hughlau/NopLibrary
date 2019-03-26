using FluentValidation.Attributes;
using Nl.Web.Areas.Admin.Models.Common;
using Nl.Web.Areas.Admin.Validators.Shipping;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a warehouse model
    /// </summary>
    [Validator(typeof(WarehouseValidator))]
    public partial class WarehouseModel : BaseNopEntityModel
    {
        #region Ctor

        public WarehouseModel()
        {
            Address = new AddressModel();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.AdminComment")]
        public string AdminComment { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Warehouses.Fields.Address")]
        public AddressModel Address { get; set; }

        #endregion
    }
}