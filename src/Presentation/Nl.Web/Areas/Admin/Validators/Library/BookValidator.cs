using Nl.Data;
using Nl.Services.Localization;
using Nl.Web.Areas.Admin.Models.Library;
using Nl.WebFramework.Validators;
using FluentValidation;
using Nl.Services.Seo;
using Nl.Core.Domain.Library;
using Nl.Web.Areas.Admin.Models.Library.Book;

/****************************************************************
*   Author：L
*   Time：2019/4/4 13:57:56
*   Description：
*
*****************************************************************/

namespace Nl.Web.Areas.Admin.Validators.Library
{
    public class BookValidator : BaseNopValidator<BookModel>
    {
        #region =============属性============



        #endregion

        #region ===========构造函数==========

        public BookValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.Library.Categories.Fields.Name.Required"));
            SetDatabaseValidationRules<LibraryCategory>(dbContext);
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============



        #endregion
    }
}
