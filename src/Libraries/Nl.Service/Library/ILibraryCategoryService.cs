using Nl.Core;
using Nl.Core.Domain.Library;
using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*   Author：L
*   Time：2019/3/29 14:37:18
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Service.Library
{
    public interface ILibraryCategoryService
    {

        #region =============方法============

        void DeleteCategory(LibraryCategory category);

        IList<LibraryCategory> GetAllCategories(int storeId = 0, bool showHidden = false, bool loadCacheableCopy = true);

        IPagedList<LibraryCategory> GetAllCategories(string categoryName, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        IList<LibraryCategory> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false);


        IList<LibraryCategory> GetAllCategoriesDisplayedOnHomePage(bool showHidden = false);


        IList<int> GetChildCategoryIds(int parentCategoryId, int storeId = 0, bool showHidden = false);


        LibraryCategory GetCategoryById(int categoryId);


        void InsertCategory(LibraryCategory category);


        void UpdateCategory(LibraryCategory category);

        


        string[] GetNotExistingCategories(string[] categoryIdsNames);




        List<LibraryCategory> GetCategoriesByIds(int[] categoryIds);


        IList<LibraryCategory> SortCategoriesForTree(IList<LibraryCategory> source, int parentId = 0,
            bool ignoreCategoriesWithoutExistingParent = false);




        string GetFormattedBreadCrumb(LibraryCategory category, IList<LibraryCategory> allCategories = null,
            string separator = ">>", int languageId = 0);


        IList<LibraryCategory> GetCategoryBreadCrumb(LibraryCategory category, IList<LibraryCategory> allCategories = null, bool showHidden = false);

        #endregion
    }
}