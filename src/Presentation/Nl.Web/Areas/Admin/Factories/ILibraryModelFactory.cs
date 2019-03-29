using Nl.Web.Areas.Admin.Models.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2019/3/29 10:47:37
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Factories
{
    public partial interface ILibraryModelFactory
    {
        #region =============属性============



        #endregion

        #region ===========构造函数==========



        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        LibraryListModel PrepareLibraryListModel(LibrarySearchModel searchModel);

        #endregion
    }
}
