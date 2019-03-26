using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a specification attribute option search model
    /// </summary>
    public partial class SpecificationAttributeOptionSearchModel : BaseSearchModel
    {
        #region Properties

        public int SpecificationAttributeId { get; set; }

        #endregion
    }
}