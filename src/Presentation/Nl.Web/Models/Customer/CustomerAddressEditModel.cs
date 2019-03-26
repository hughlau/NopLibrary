using Nl.WebFramework.Models;
using Nl.Web.Models.Common;

namespace Nl.Web.Models.Customer
{
    public partial class CustomerAddressEditModel : BaseNopModel
    {
        public CustomerAddressEditModel()
        {
            Address = new AddressModel();
        }
        
        public AddressModel Address { get; set; }
    }
}