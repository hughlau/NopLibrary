using System.Collections.Generic;
using Nl.WebFramework.Models;
using Nl.Web.Models.Common;

namespace Nl.Web.Models.Customer
{
    public partial class CustomerAddressListModel : BaseNopModel
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }
}