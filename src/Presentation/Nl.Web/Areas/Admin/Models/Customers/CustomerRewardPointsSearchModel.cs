using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a reward points search model
    /// </summary>
    public partial class CustomerRewardPointsSearchModel : BaseSearchModel
    {
        #region Properties

        public int CustomerId { get; set; }
        
        #endregion
    }
}