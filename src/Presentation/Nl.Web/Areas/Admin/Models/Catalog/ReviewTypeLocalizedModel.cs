using Nl.WebFramework.Models;
using Nl.WebFramework.Mvc.ModelBinding;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a review type localized model
    /// </summary>
    public partial class ReviewTypeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Description")]
        public string Description { get; set; }
    }
}
