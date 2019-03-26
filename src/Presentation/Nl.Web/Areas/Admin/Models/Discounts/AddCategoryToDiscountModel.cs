using System.Collections.Generic;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a category model to add to the discount
    /// </summary>
    public partial class AddCategoryToDiscountModel : BaseNopModel
    {
        #region Ctor

        public AddCategoryToDiscountModel()
        {
            SelectedCategoryIds = new List<int>();
        }
        #endregion

        #region Properties

        public int DiscountId { get; set; }

        public IList<int> SelectedCategoryIds { get; set; }

        #endregion
    }
}