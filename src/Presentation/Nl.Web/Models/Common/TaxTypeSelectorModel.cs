using Nl.Core.Domain.Tax;
using Nl.WebFramework.Models;

namespace Nl.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseNopModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}