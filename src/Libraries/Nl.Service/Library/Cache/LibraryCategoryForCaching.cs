using Newtonsoft.Json;
using Nl.Core.Caching;
using Nl.Core.Domain.Library;
using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*   Author：L
*   Time：2019/3/29 15:08:19
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Service.Library
{
    public partial class LibraryCategoryForCaching:LibraryCategory, IEntityForCaching
    {

        #region =============属性============



        #endregion

        #region ===========构造函数==========

        public LibraryCategoryForCaching(LibraryCategory c)
        {
            Id = c.Id;
            Name = c.Name;
            Description = c.Description;
            CategoryTemplateId = c.CategoryTemplateId;
            MetaKeywords = c.MetaKeywords;
            MetaDescription = c.MetaDescription;
            MetaTitle = c.MetaTitle;
            ParentCategoryId = c.ParentCategoryId;
            PictureId = c.PictureId;
            PageSize = c.PageSize;
            AllowCustomersToSelectPageSize = c.AllowCustomersToSelectPageSize;
            PageSizeOptions = c.PageSizeOptions;
            PriceRanges = c.PriceRanges;
            ShowOnHomePage = c.ShowOnHomePage;
            IncludeInTopMenu = c.IncludeInTopMenu;
            SubjectToAcl = c.SubjectToAcl;
            LimitedToStores = c.LimitedToStores;
            Published = c.Published;
            Deleted = c.Deleted;
            DisplayOrder = c.DisplayOrder;
            CreatedOnUtc = c.CreatedOnUtc;
            UpdatedOnUtc = c.UpdatedOnUtc;
        }


        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion
    }
}
