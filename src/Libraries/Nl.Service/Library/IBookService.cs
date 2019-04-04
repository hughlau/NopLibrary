using Nl.Core;
using Nl.Core.Domain.Library;
using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*   Author：L
*   Time：2019/4/4 10:51:43
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Service.Library
{
    public interface IBookService
    {

        #region =============方法============

        IPagedList<Book> GetAllBooks(string bookName, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        #endregion
    }
}