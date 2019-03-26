using System.Collections.Generic;
using System.Linq;
using Nl.Core;
using Nl.Services.Authentication.External;
using Nl.Web.Models.Customer;

namespace Nl.Web.Factories
{
    /// <summary>
    /// Represents the external authentication model factory
    /// </summary>
    public partial class ExternalAuthenticationModelFactory : IExternalAuthenticationModelFactory
    {
        #region Fields

        private readonly IExternalAuthenticationService _externalAuthenticationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public ExternalAuthenticationModelFactory(IExternalAuthenticationService externalAuthenticationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _externalAuthenticationService = externalAuthenticationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare the external authentication method model
        /// </summary>
        /// <returns>List of the external authentication method model</returns>
        public virtual List<ExternalAuthenticationMethodModel> PrepareExternalMethodsModel()
        {
            return _externalAuthenticationService
                .LoadActiveExternalAuthenticationMethods(_workContext.CurrentCustomer, _storeContext.CurrentStore.Id)
                .Select(authenticationMethod => new ExternalAuthenticationMethodModel
                {
                    ViewComponentName = authenticationMethod.GetPublicViewComponentName()
                }).ToList();
        }

        #endregion
    }
}
