using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a never sold products report model
    /// </summary>
    public partial class NeverSoldReportModel : BaseNopModel
    {
        #region Properties

        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Reports.Sales.NeverSold.Fields.Name")]
        public string ProductName { get; set; }

        #endregion
    }
}