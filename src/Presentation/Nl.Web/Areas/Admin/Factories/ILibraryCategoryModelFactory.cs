using Nl.Web.Areas.Admin.Models.Library;
using Nl.Web.Areas.Admin.Models.Library.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2019/3/29 14:33:12
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Factories
{
    public interface ILibraryCategoryModelFactory
    {
        LibraryCategorySearchModel PrepareCategorySearchModel(LibraryCategorySearchModel searchModel);

        LibraryCategoryListModel PrepareCategoryListModel(LibraryCategorySearchModel searchModel);
    }
}
