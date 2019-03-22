using Nop.Core.Domain.Tax;
using Nl.Web.Framework.Models;

namespace Nop.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseNopModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}