using Nl.Core.Caching;
using Nl.Core.Domain.Library;
using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*   Author：L
*   Time：2019/4/4 11:12:13
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Service.Library.Cache
{
    public partial class BookForCaching : Book, IEntityForCaching
    {

        #region =============属性============



        #endregion

        #region ===========构造函数==========

        public BookForCaching(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            CategoryTitle = book.CategoryTitle;
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion
    }
}
