using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nl.Core;
using Nl.Core.Caching;
using Nl.Core.Data;
using Nl.Core.Data.Extensions;
using Nl.Core.Domain.Common;
using Nl.Core.Domain.Customers;
using Nl.Core.Domain.Library;
using Nl.Core.Domain.Library.Setting;
using Nl.Core.Domain.Security;
using Nl.Core.Domain.Stores;
using Nl.Data;
using Nl.Services.Events;
using Nl.Services.Localization;
using Nl.Services.Security;
using Nl.Services.Stores;

/****************************************************************
*   Author：L
*   Time：2019/4/4 10:51:52
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Service.Library
{
    public partial class BookService : IBookService
    {

        #region =============属性============

        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<Book> _bookRepository;

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region ===========构造函数==========

        public BookService(ICacheManager cacheManager
            , IDataProvider dataProvider
            , IDbContext dbContext
            ,IEventPublisher eventPublisher
            ,ILocalizationService localizationService
            ,IRepository<Book> repository
            ,IStaticCacheManager staticCacheManager
            ,IWorkContext workContext)
        {
            this._cacheManager = cacheManager;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._eventPublisher = eventPublisher;
            this._localizationService = localizationService;
            this._bookRepository = repository;
            this._staticCacheManager = staticCacheManager;
            this._workContext = workContext;
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        public IPagedList<Book> GetAllBooks(string bookName, int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _bookRepository.Table;
            if (!string.IsNullOrWhiteSpace(bookName))
                query = query.Where(c => c.Title.Contains(bookName));
            query = query.Where(c => c.Flag.Equals(0));
            query = query.OrderBy(c => c.Id).ThenBy(c => c.CID);

            var unsortedCategories = query.ToList();

            //paging
            return new PagedList<Book>(unsortedCategories, pageIndex, pageSize);
        }

        #endregion

    }
}
