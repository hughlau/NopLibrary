using Nl.Web.Areas.Admin.Models.Library.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2019/4/4 11:17:27
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Factories.Library
{
    public interface IBookModelFactory
    {
        #region =============属性============



        #endregion

        #region ===========构造函数==========



        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        BookListModel PrepareBookListModel(BookSearchModel searchModel);

        BookModel PrepareBookModel(BookSearchModel model, bool excludeProperties = false);

        BookSearchModel PrepareBookSearchModel(BookSearchModel model);

        #endregion
    }
}
