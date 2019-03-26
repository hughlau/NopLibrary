using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an address attribute value search model
    /// </summary>
    public partial class AddressAttributeValueSearchModel : BaseSearchModel
    {
        #region Properties

        public int AddressAttributeId { get; set; }

        #endregion
    }
}