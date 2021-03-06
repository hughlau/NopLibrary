﻿using System;
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
*   Time：2019/3/29 14:37:30
*   FrameVersion：2.2
*   Description：
*
*****************************************************************/
namespace Nl.Service.Library
{
    public partial class LibraryCategoryService : ILibraryCategoryService
    {


        #region 属性

        private readonly LibrarySettings _librarySettings;
        private readonly CommonSettings _commonSettings;
        private readonly IAclService _aclService;
        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<AclRecord> _aclRepository;
        private readonly IRepository<LibraryCategory> _categoryRepository;

        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region 构造方法

        public LibraryCategoryService(
            LibrarySettings librarySettings,
            CommonSettings commonSettings,
            IAclService aclService,
            ICacheManager cacheManager,
            IDataProvider dataProvider,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IRepository<AclRecord> aclRepository,
            IRepository<LibraryCategory> categoryRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _librarySettings = librarySettings;
            _commonSettings = commonSettings;
            _aclService = aclService;
            _cacheManager = cacheManager;
            _dataProvider = dataProvider;
            _dbContext = dbContext;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _aclRepository = aclRepository;
            _categoryRepository = categoryRepository;
            _storeMappingRepository = storeMappingRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        public void DeleteCategory(LibraryCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (category is IEntityForCaching)
                throw new ArgumentException("Cacheable entities are not supported by Entity Framework");

            category.Deleted = true;
            UpdateCategory(category);

            //event notification
            _eventPublisher.EntityDeleted(category);

            //reset a "Parent category" property of all child subcategories
            var subcategories = GetAllCategoriesByParentCategoryId(category.Id, true);
            foreach (var subcategory in subcategories)
            {
                subcategory.ParentCategoryId = 0;
                UpdateCategory(subcategory);
            }
        }

        public IList<LibraryCategory> GetAllCategories(int storeId = 0, bool showHidden = false, bool loadCacheableCopy = true)
        {
            IList<LibraryCategory> LoadCategoriesFunc() => GetAllCategories(string.Empty, storeId, showHidden: showHidden);

            IList<LibraryCategory> categories;
            if (loadCacheableCopy)
            {
                //cacheable copy
                var key = string.Format(NopLibraryDefaults.CategoriesAllCacheKey,
                    storeId,
                    string.Join(",", _workContext.CurrentCustomer.GetCustomerRoleIds()),
                    showHidden);
                categories = _staticCacheManager.Get(key, () =>
                {
                    var result = new List<LibraryCategory>();
                    foreach (var category in LoadCategoriesFunc())
                        result.Add(new LibraryCategoryForCaching(category));
                    return result;
                });
            }
            else
            {
                categories = LoadCategoriesFunc();
            }

            return categories;
        }

        public IPagedList<LibraryCategory> GetAllCategories(string categoryName, int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            if (_commonSettings.UseStoredProcedureForLoadingCategories)
            {
                //stored procedures are enabled for loading categories and supported by the database. 
                //It's much faster with a large number of categories than the LINQ implementation below 

                //prepare parameters
                var showHiddenParameter = _dataProvider.GetBooleanParameter("ShowHidden", showHidden);
                var nameParameter = _dataProvider.GetStringParameter("Name", categoryName ?? string.Empty);
                var storeIdParameter = _dataProvider.GetInt32Parameter("StoreId", !_librarySettings.IgnoreStoreLimitations ? storeId : 0);
                var pageIndexParameter = _dataProvider.GetInt32Parameter("PageIndex", pageIndex);
                var pageSizeParameter = _dataProvider.GetInt32Parameter("PageSize", pageSize);
                //pass allowed customer role identifiers as comma-delimited string
                var customerRoleIdsParameter = _dataProvider.GetStringParameter("CustomerRoleIds", !_librarySettings.IgnoreAcl ? string.Join(",", _workContext.CurrentCustomer.GetCustomerRoleIds()) : string.Empty);

                var totalRecordsParameter = _dataProvider.GetOutputInt32Parameter("TotalRecords");

                //invoke stored procedure
                var categories = _dbContext.EntityFromSql<LibraryCategory>("LibraryCategoryLoadAllPaged",
                    showHiddenParameter, nameParameter, storeIdParameter, customerRoleIdsParameter,
                    pageIndexParameter, pageSizeParameter, totalRecordsParameter).ToList();
                var totalRecords = totalRecordsParameter.Value != DBNull.Value ? Convert.ToInt32(totalRecordsParameter.Value) : 0;

                //paging
                return new PagedList<LibraryCategory>(categories, pageIndex, pageSize, totalRecords);
            }

            //don't use a stored procedure. Use LINQ
            var query = _categoryRepository.Table;
            if (!showHidden)
                query = query.Where(c => c.Published);
            if (!string.IsNullOrWhiteSpace(categoryName))
                query = query.Where(c => c.Name.Contains(categoryName));
            query = query.Where(c => !c.Deleted);
            query = query.OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder).ThenBy(c => c.Id);

            if ((storeId > 0 && !_librarySettings.IgnoreStoreLimitations) || (!showHidden && !_librarySettings.IgnoreAcl))
            {
                if (!showHidden && !_librarySettings.IgnoreAcl)
                {
                    //ACL (access control list)
                    var allowedCustomerRolesIds = _workContext.CurrentCustomer.GetCustomerRoleIds();
                    query = from c in query
                            join acl in _aclRepository.Table
                                on new { c1 = c.Id, c2 = nameof(LibraryCategory) } equals new { c1 = acl.EntityId, c2 = acl.EntityName } into c_acl
                            from acl in c_acl.DefaultIfEmpty()
                            where !c.SubjectToAcl || allowedCustomerRolesIds.Contains(acl.CustomerRoleId)
                            select c;
                }

                if (storeId > 0 && !_librarySettings.IgnoreStoreLimitations)
                {
                    //Store mapping
                    query = from c in query
                            join sm in _storeMappingRepository.Table
                                on new { c1 = c.Id, c2 = nameof(LibraryCategory) } equals new { c1 = sm.EntityId, c2 = sm.EntityName } into c_sm
                            from sm in c_sm.DefaultIfEmpty()
                            where !c.LimitedToStores || storeId == sm.StoreId
                            select c;
                }

                query = query.Distinct().OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder).ThenBy(c => c.Id);
            }

            var unsortedCategories = query.ToList();

            //sort categories
            var sortedCategories = SortCategoriesForTree(unsortedCategories);

            //paging
            return new PagedList<LibraryCategory>(sortedCategories, pageIndex, pageSize);
        }

        public IList<LibraryCategory> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false)
        {
            var key = string.Format(NopLibraryDefaults.CategoriesByParentCategoryIdCacheKey, parentCategoryId, showHidden, _workContext.CurrentCustomer.Id, _storeContext.CurrentStore.Id);
            return _cacheManager.Get(key, () =>
            {
                var query = _categoryRepository.Table;
                if (!showHidden)
                    query = query.Where(c => c.Published);
                query = query.Where(c => c.ParentCategoryId == parentCategoryId);
                query = query.Where(c => !c.Deleted);
                query = query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);

                if (!showHidden && (!_librarySettings.IgnoreAcl || !_librarySettings.IgnoreStoreLimitations))
                {
                    if (!_librarySettings.IgnoreAcl)
                    {
                        //ACL (access control list)
                        var allowedCustomerRolesIds = _workContext.CurrentCustomer.GetCustomerRoleIds();
                        query = from c in query
                                join acl in _aclRepository.Table
                                on new { c1 = c.Id, c2 = nameof(LibraryCategory) } equals new { c1 = acl.EntityId, c2 = acl.EntityName } into c_acl
                                from acl in c_acl.DefaultIfEmpty()
                                where !c.SubjectToAcl || allowedCustomerRolesIds.Contains(acl.CustomerRoleId)
                                select c;
                    }

                    if (!_librarySettings.IgnoreStoreLimitations)
                    {
                        //Store mapping
                        var currentStoreId = _storeContext.CurrentStore.Id;
                        query = from c in query
                                join sm in _storeMappingRepository.Table
                                on new { c1 = c.Id, c2 = nameof(LibraryCategory) } equals new { c1 = sm.EntityId, c2 = sm.EntityName } into c_sm
                                from sm in c_sm.DefaultIfEmpty()
                                where !c.LimitedToStores || currentStoreId == sm.StoreId
                                select c;
                    }

                    query = query.Distinct().OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);
                }

                var categories = query.ToList();
                return categories;
            });
        }

        public IList<LibraryCategory> GetAllCategoriesDisplayedOnHomePage(bool showHidden = false)
        {
            var query = from c in _categoryRepository.Table
                        orderby c.DisplayOrder, c.Id
                        where c.Published &&
                        !c.Deleted &&
                        c.ShowOnHomePage
                        select c;

            var categories = query.ToList();
            if (!showHidden)
            {
                categories = categories
                    .Where(c => _aclService.Authorize(c) && _storeMappingService.Authorize(c))
                    .ToList();
            }

            return categories;
        }

        public List<LibraryCategory> GetCategoriesByIds(int[] categoryIds)
        {
            if (categoryIds == null || categoryIds.Length == 0)
                return new List<LibraryCategory>();

            var query = from p in _categoryRepository.Table
                        where categoryIds.Contains(p.Id) && !p.Deleted
                        select p;

            return query.ToList();
        }

        public IList<LibraryCategory> GetCategoryBreadCrumb(LibraryCategory category, IList<LibraryCategory> allCategories = null, bool showHidden = false)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var result = new List<LibraryCategory>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>();

            while (category != null && //not null
                !category.Deleted && //not deleted
                (showHidden || category.Published) && //published
                (showHidden || _aclService.Authorize(category)) && //ACL
                (showHidden || _storeMappingService.Authorize(category)) && //Store mapping
                !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = allCategories != null ? allCategories.FirstOrDefault(c => c.Id == category.ParentCategoryId)
                    : GetCategoryById(category.ParentCategoryId);
            }

            result.Reverse();
            return result;
        }

        public LibraryCategory GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            var key = string.Format(NopLibraryDefaults.CategoriesByIdCacheKey, categoryId);
            return _cacheManager.Get(key, () => _categoryRepository.GetById(categoryId));
        }

        public IList<int> GetChildCategoryIds(int parentCategoryId, int storeId = 0, bool showHidden = false)
        {
            var cacheKey = string.Format(NopLibraryDefaults.CategoriesChildIdentifiersCacheKey,
                parentCategoryId,
                string.Join(",", _workContext.CurrentCustomer.GetCustomerRoleIds()),
                _storeContext.CurrentStore.Id,
                showHidden);
            return _staticCacheManager.Get(cacheKey, () =>
            {
                //little hack for performance optimization
                //there's no need to invoke "GetAllCategoriesByParentCategoryId" multiple times (extra SQL commands) to load childs
                //so we load all categories at once (we know they are cached) and process them server-side
                var categoriesIds = new List<int>();
                var categories = GetAllCategories(storeId: storeId, showHidden: showHidden)
                    .Where(c => c.ParentCategoryId == parentCategoryId);
                foreach (var category in categories)
                {
                    categoriesIds.Add(category.Id);
                    categoriesIds.AddRange(GetChildCategoryIds(category.Id, storeId, showHidden));
                }

                return categoriesIds;
            });
        }

        public string GetFormattedBreadCrumb(LibraryCategory category, IList<LibraryCategory> allCategories = null, string separator = ">>", int languageId = 0)
        {
            var result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(category, allCategories, true);
            for (var i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = _localizationService.GetLocalized(breadcrumb[i], x => x.Name, languageId);
                result = string.IsNullOrEmpty(result) ? categoryName : $"{result} {separator} {categoryName}";
            }

            return result;
        }

        public string[] GetNotExistingCategories(string[] categoryIdsNames)
        {
            if (categoryIdsNames == null)
                throw new ArgumentNullException(nameof(categoryIdsNames));

            var query = _categoryRepository.Table;
            var queryFilter = categoryIdsNames.Distinct().ToArray();
            //filtering by name
            var filter = query.Select(c => c.Name).Where(c => queryFilter.Contains(c)).ToList();
            queryFilter = queryFilter.Except(filter).ToArray();

            //if some names not found
            if (!queryFilter.Any())
                return queryFilter.ToArray();

            //filtering by IDs
            filter = query.Select(c => c.Id.ToString()).Where(c => queryFilter.Contains(c)).ToList();
            queryFilter = queryFilter.Except(filter).ToArray();

            return queryFilter.ToArray();
        }



        public void InsertCategory(LibraryCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (category is IEntityForCaching)
                throw new ArgumentException("Cacheable entities are not supported by Entity Framework");

            _categoryRepository.Insert(category);

            //cache
            _cacheManager.RemoveByPattern(NopLibraryDefaults.CategoriesPatternCacheKey);
            _staticCacheManager.RemoveByPattern(NopLibraryDefaults.CategoriesPatternCacheKey);


            //event notification
            _eventPublisher.EntityInserted(category);
        }

        public IList<LibraryCategory> SortCategoriesForTree(IList<LibraryCategory> source, int parentId = 0, bool ignoreCategoriesWithoutExistingParent = false)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var result = new List<LibraryCategory>();

            foreach (var cat in source.Where(c => c.ParentCategoryId == parentId).ToList())
            {
                result.Add(cat);
                result.AddRange(SortCategoriesForTree(source, cat.Id, true));
            }

            if (ignoreCategoriesWithoutExistingParent || result.Count == source.Count)
                return result;

            //find categories without parent in provided category source and insert them into result
            foreach (var cat in source)
                if (result.FirstOrDefault(x => x.Id == cat.Id) == null)
                    result.Add(cat);

            return result;
        }

        public void UpdateCategory(LibraryCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (category is IEntityForCaching)
                throw new ArgumentException("Cacheable entities are not supported by Entity Framework");

            //validate category hierarchy
            var parentCategory = GetCategoryById(category.ParentCategoryId);
            while (parentCategory != null)
            {
                if (category.Id == parentCategory.Id)
                {
                    category.ParentCategoryId = 0;
                    break;
                }

                parentCategory = GetCategoryById(parentCategory.ParentCategoryId);
            }

            _categoryRepository.Update(category);

            //cache
            _cacheManager.RemoveByPattern(NopLibraryDefaults.CategoriesPatternCacheKey);
            _staticCacheManager.RemoveByPattern(NopLibraryDefaults.CategoriesPatternCacheKey);


            //event notification
            _eventPublisher.EntityUpdated(category);
        }
    }
}
