using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nl.Service.Library;
using Nl.Services.Localization;
using Nl.Services.Seo;
using Nl.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nl.Web.Areas.Admin.Models.Library.Book;
using Nl.WebFramework.Factories;

/****************************************************************
*   Author：L
*   Time：2019/4/4 11:16:24
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Factories.Library
{
    public class BookModelFactory : IBookModelFactory
    {
        #region =============属性============

        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly IBookService _bookervice;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region ===========构造函数==========

        public BookModelFactory(
            IBaseAdminModelFactory baseAdminModelFactory
            , IBookService bookService
            , ILocalizationService localizationService
            , ILocalizedModelFactory localizedModelFactory
            , IUrlRecordService urlRecordService)
        {
            this._baseAdminModelFactory = baseAdminModelFactory;
            this._bookervice = bookService;
            this._localizationService = localizationService;
            this._localizedModelFactory = localizedModelFactory;
            this._urlRecordService = urlRecordService;
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        public BookListModel PrepareBookListModel(BookSearchModel searchModel)
        {
            var books = _bookervice.GetAllBooks(searchModel.SearchBookName);

            var model = new BookListModel
            {
                Data = books.Select(book =>
                {
                    //fill in model values from the entity
                    var bookModel = book.ToModel<BookModel>();

                    return bookModel;
                }),
                Total = books.TotalCount
            };

            return model;
        }

        public BookModel PrepareBookModel(BookSearchModel model, bool excludeProperties = false)
        {
            throw new NotImplementedException();
        }

        public BookSearchModel PrepareBookSearchModel(BookSearchModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //prepare page parameters
            model.SetGridPageSize();

            return model;
        }

        #endregion

    }
}
