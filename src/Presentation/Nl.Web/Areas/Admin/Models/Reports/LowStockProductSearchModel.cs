using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.Web.Framework.Mvc.ModelBinding;
using Nl.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a low stock product search model
    /// </summary>
    public partial class LowStockProductSearchModel : BaseSearchModel
    {
        #region Ctor

        public LowStockProductSearchModel()
        {
            AvailablePublishedOptions = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Reports.LowStock.SearchPublished")]
        public int SearchPublishedId { get; set; }
        public IList<SelectListItem> AvailablePublishedOptions { get; set; }

        #endregion
    }
}