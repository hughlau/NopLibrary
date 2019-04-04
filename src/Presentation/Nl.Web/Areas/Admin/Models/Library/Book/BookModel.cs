using FluentValidation.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.Web.Areas.Admin.Validators.Library;
using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2019/4/4 11:19:02
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Models.Library.Book
{
    [Validator(typeof(BookValidator))]
    public class BookModel : BaseNopEntityModel,ILocalizedModel<BookLocalizedModel>
    {
        #region =============属性============

        [NopResourceDisplayName("Admin.Library.Book.Fields.Name")]
        public string Title { get; set; }

        [NopResourceDisplayName("Admin.Library.Book.Fields.Name")]
        public string CategoryTitle { get; set; }

        [NopResourceDisplayName("Admin.Library.Book.Fields.Description")]
        public string KeyWords { get; set; }


        public IList<BookLocalizedModel> Locales { get; set; }

        #endregion

        #region ===========构造函数==========

        public BookModel()
        {
            Locales = new List<BookLocalizedModel>();
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion
    }

    public partial class BookLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Library.Book.Fields.Name")]
        public string Title { get; set; }

        [NopResourceDisplayName("Admin.Library.Book.Fields.Name")]
        public string CategoryTitle { get; set; }

        [NopResourceDisplayName("Admin.Library.Book.Fields.Description")]
        public string KeyWords { get; set; }
    }
}
