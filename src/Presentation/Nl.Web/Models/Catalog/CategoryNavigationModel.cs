using System.Collections.Generic;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Catalog
{
    public partial class CategoryNavigationModel : BaseNopModel
    {
        public CategoryNavigationModel()
        {
            Categories = new List<CategorySimpleModel>();
        }

        public int CurrentCategoryId { get; set; }
        public List<CategorySimpleModel> Categories { get; set; }

        #region Nested classes

        public class CategoryLineModel : BaseNopModel
        {
            public int CurrentCategoryId { get; set; }
            public CategorySimpleModel Category { get; set; }
        }

        #endregion
    }
}