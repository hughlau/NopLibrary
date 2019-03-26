﻿using Nl.Web.Areas.Admin.Models.Common;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Orders
{
    public partial class OrderAddressModel : BaseNopModel
    {
        #region Ctor

        public OrderAddressModel()
        {
            Address = new AddressModel();
        }

        #endregion

        #region Properties

        public int OrderId { get; set; }

        public AddressModel Address { get; set; }

        #endregion
    }
}