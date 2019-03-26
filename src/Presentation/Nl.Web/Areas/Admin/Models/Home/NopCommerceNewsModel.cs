using System.Collections.Generic;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a nopCommerce news model
    /// </summary>
    public partial class NopCommerceNewsModel : BaseNopModel
    {
        #region Ctor

        public NopCommerceNewsModel()
        {
            Items = new List<NopCommerceNewsDetailsModel>();
        }

        #endregion

        #region Properties

        public List<NopCommerceNewsDetailsModel> Items { get; set; }

        public bool HasNewItems { get; set; }

        public bool HideAdvertisements { get; set; }

        #endregion
    }
}