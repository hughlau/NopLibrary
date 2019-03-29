using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2019/3/29 15:59:02
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Models.Library.Category
{
    public class LibraryCategorySearchModel:BaseSearchModel
    {
        #region =============属性============

        [NopResourceDisplayName("Admin.Library.Categories.List.SearchCategoryName")]
        public string SearchCategoryName { get; set; }

        [NopResourceDisplayName("Admin.Library.Categories.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion

        #region ===========构造函数==========

        public LibraryCategorySearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion
    }
}
