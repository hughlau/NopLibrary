using Nl.Data;
using Nl.Services.Localization;
using Nl.Web.Areas.Admin.Models.Library;
using Nl.WebFramework.Validators;
using FluentValidation;
using Nl.Services.Seo;
using Nl.Core.Domain.Library;

/****************************************************************
*   Author：L
*   Time：2019/3/29 13:57:57
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Validators.Library
{
    public class LibraryCategoryValidator: BaseNopValidator<LibraryCategoryModel>
    {
        #region =============属性============



        #endregion

        #region ===========构造函数==========

        public LibraryCategoryValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Library.Categories.Fields.Name.Required"));
            RuleFor(x => x.PageSizeOptions).Must(ValidatorUtilities.PageSizeOptionsValidator).WithMessage(localizationService.GetResource("Admin.Library.Categories.Fields.PageSizeOptions.ShouldHaveUniqueItems"));
            RuleFor(x => x.PageSize).Must((x, context) =>
            {
                if (!x.AllowCustomersToSelectPageSize && x.PageSize <= 0)
                    return false;

                return true;
            }).WithMessage(localizationService.GetResource("Admin.Library.Categories.Fields.PageSize.Positive"));
            RuleFor(x => x.SeName).Length(0, NopSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<LibraryCategory>(dbContext);
        }

        #endregion


    }
}
