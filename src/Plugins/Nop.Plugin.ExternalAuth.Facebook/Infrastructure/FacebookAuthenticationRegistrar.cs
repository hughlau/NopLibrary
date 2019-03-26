using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.DependencyInjection;
using Nl.Core.Infrastructure;
using Nl.Services.Authentication.External;

namespace Nop.Plugin.ExternalAuth.Facebook.Infrastructure
{
    /// <summary>
    /// Registration of Facebook authentication service (plugin)
    /// </summary>
    public class FacebookAuthenticationRegistrar : IExternalAuthenticationRegistrar
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">Authentication builder</param>
        public void Configure(AuthenticationBuilder builder)
        {
            builder.AddFacebook(FacebookDefaults.AuthenticationScheme, options =>
            {
                var settings = EngineContext.Current.Resolve<FacebookExternalAuthSettings>();

                options.AppId = settings.ClientKeyIdentifier;
                options.AppSecret = settings.ClientSecret;
                options.SaveTokens = true;

                options.Events = new OAuthEvents
                {
                    OnRemoteFailure = ctx =>
                    {
                        ctx.HandleResponse();
                        ctx.Response.Redirect(ctx.Properties.GetString("ErrorCallback"));
                        return Task.FromResult(0);
                    }
                };
            });
        }
    }
}
