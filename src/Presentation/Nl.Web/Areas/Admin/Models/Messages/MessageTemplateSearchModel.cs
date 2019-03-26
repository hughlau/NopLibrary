using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nl.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a message template search model
    /// </summary>
    public partial class MessageTemplateSearchModel : BaseSearchModel
    {
        #region Ctor

        public MessageTemplateSearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.MessageTemplates.List.SearchStore")]
        public int SearchStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}