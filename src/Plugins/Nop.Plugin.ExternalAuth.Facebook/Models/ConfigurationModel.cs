using Nl.WebFramework.Mvc.ModelBinding;
using Nl.WebFramework.Models;

namespace Nop.Plugin.ExternalAuth.Facebook.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.ExternalAuth.Facebook.ClientKeyIdentifier")]
        public string ClientId { get; set; }

        [NopResourceDisplayName("Plugins.ExternalAuth.Facebook.ClientSecret")]
        public string ClientSecret { get; set; }
    }
}