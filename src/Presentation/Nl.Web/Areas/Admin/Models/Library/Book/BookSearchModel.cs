using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2019/4/4 11:18:36
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Models.Library.Book
{
    public class BookSearchModel:BaseSearchModel
    {
        #region =============属性============

        [NopResourceDisplayName("Admin.Library.Categories.List.SearchCategoryName")]
        public string SearchBookName { get; set; }

        #endregion

        #region ===========构造函数==========

        public BookSearchModel() { }

        #endregion


    }
}
