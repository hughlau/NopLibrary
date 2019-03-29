using Nl.Core.Domain.Library.Setting;
using Nl.Service.Library;
using Nl.Services.Discounts;
using Nl.Services.Localization;
using Nl.Services.Seo;
using Nl.Web.Areas.Admin.Models.Library;
using Nl.Web.Areas.Admin.Models.Library.Category;
using Nl.WebFramework.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Nl.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nl.Core.Domain.Library;
using Nl.Core.Domain.Discounts;

/****************************************************************
*   Author：L
*   Time：2019/3/29 16:03:58
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Factories.Library
{
    public class LibraryCategoryModelFactory: ILibraryCategoryModelFactory
    {
        #region =============属性============

        private readonly LibrarySettings _catalogSettings;
        private readonly IAclSupportedModelFactory _aclSupportedModelFactory;
        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly ILibraryCategoryService _categoryService;
        private readonly IDiscountService _discountService;
        private readonly IDiscountSupportedModelFactory _discountSupportedModelFactory;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IStoreMappingSupportedModelFactory _storeMappingSupportedModelFactory;
        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region ===========构造函数==========

        public LibraryCategoryModelFactory(LibrarySettings catalogSettings,
            IAclSupportedModelFactory aclSupportedModelFactory,
            IBaseAdminModelFactory baseAdminModelFactory,
            ILibraryCategoryService categoryService,
            IDiscountService discountService,
            IDiscountSupportedModelFactory discountSupportedModelFactory,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IStoreMappingSupportedModelFactory storeMappingSupportedModelFactory,
            IUrlRecordService urlRecordService)
        {
            _catalogSettings = catalogSettings;
            _aclSupportedModelFactory = aclSupportedModelFactory;
            _baseAdminModelFactory = baseAdminModelFactory;
            _categoryService = categoryService;
            _discountService = discountService;
            _discountSupportedModelFactory = discountSupportedModelFactory;
            _localizationService = localizationService;
            _localizedModelFactory = localizedModelFactory;
            _storeMappingSupportedModelFactory = storeMappingSupportedModelFactory;
            _urlRecordService = urlRecordService;
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        public virtual LibraryCategorySearchModel PrepareCategorySearchModel(LibraryCategorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare available stores
            _baseAdminModelFactory.PrepareStores(searchModel.AvailableStores);

            searchModel.HideStoresList = _catalogSettings.IgnoreStoreLimitations ;

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged category list model
        /// </summary>
        /// <param name="searchModel">Category search model</param>
        /// <returns>Category list model</returns>
        public virtual LibraryCategoryListModel PrepareCategoryListModel(LibraryCategorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get categories
            var categories = _categoryService.GetAllCategories(categoryName: searchModel.SearchCategoryName,
                showHidden: true,
                storeId: searchModel.SearchStoreId,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = new LibraryCategoryListModel
            {
                Data = categories.Select(category =>
                {
                    //fill in model values from the entity
                    var categoryModel = category.ToModel<LibraryCategoryModel>();

                    //fill in additional values (not existing in the entity)
                    categoryModel.Breadcrumb = _categoryService.GetFormattedBreadCrumb(category);
                    categoryModel.SeName = _urlRecordService.GetSeName(category, 0, true, false);

                    return categoryModel;
                }),
                Total = categories.TotalCount
            };

            return model;
        }

        public virtual LibraryCategoryModel PrepareCategoryModel(LibraryCategoryModel model, LibraryCategory category, bool excludeProperties = false)
        {
            Action<LibraryCategoryLocalizedModel, int> localizedModelConfiguration = null;

            if (category != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = category.ToModel<LibraryCategoryModel>();
                    model.SeName = _urlRecordService.GetSeName(category, 0, true, false);
                }

                //define localized model configuration action
                localizedModelConfiguration = (locale, languageId) =>
                {
                    locale.Name = _localizationService.GetLocalized(category, entity => entity.Name, languageId, false, false);
                    locale.Description = _localizationService.GetLocalized(category, entity => entity.Description, languageId, false, false);
                    locale.MetaKeywords = _localizationService.GetLocalized(category, entity => entity.MetaKeywords, languageId, false, false);
                    locale.MetaDescription = _localizationService.GetLocalized(category, entity => entity.MetaDescription, languageId, false, false);
                    locale.MetaTitle = _localizationService.GetLocalized(category, entity => entity.MetaTitle, languageId, false, false);
                    locale.SeName = _urlRecordService.GetSeName(category, languageId, false, false);
                };
            }

            //set default values for the new model
            if (category == null)
            {
                model.PageSize = _catalogSettings.DefaultCategoryPageSize;
                model.PageSizeOptions = _catalogSettings.DefaultCategoryPageSizeOptions;
                model.Published = true;
                model.IncludeInTopMenu = true;
                model.AllowCustomersToSelectPageSize = true;
            }

            //prepare localized models
            if (!excludeProperties)
                model.Locales = _localizedModelFactory.PrepareLocalizedModels(localizedModelConfiguration);

            //prepare available category templates
            _baseAdminModelFactory.PrepareCategoryTemplates(model.AvailableCategoryTemplates, false);

            //prepare available parent categories
            _baseAdminModelFactory.PrepareCategories(model.AvailableCategories,
                defaultItemText: _localizationService.GetResource("Admin.Library.Categories.Fields.Parent.None"));

            //prepare model discounts
            var availableDiscounts = _discountService.GetAllDiscounts(DiscountType.AssignedToCategories, showHidden: true);
            _discountSupportedModelFactory.PrepareModelDiscounts(model, category, availableDiscounts, excludeProperties);

            //prepare model customer roles
            _aclSupportedModelFactory.PrepareModelCustomerRoles(model, category, excludeProperties);

            //prepare model stores
            _storeMappingSupportedModelFactory.PrepareModelStores(model, category, excludeProperties);

            return model;
        }

        #endregion
    }
}
