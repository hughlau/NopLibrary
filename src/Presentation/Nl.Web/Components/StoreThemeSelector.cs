using Microsoft.AspNetCore.Mvc;
using Nl.Core.Domain;
using Nl.Web.Factories;
using Nl.WebFramework.Components;

namespace Nl.Web.Components
{
    public class StoreThemeSelectorViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;
        private readonly StoreInformationSettings _storeInformationSettings;

        public StoreThemeSelectorViewComponent(ICommonModelFactory commonModelFactory,
            StoreInformationSettings storeInformationSettings)
        {
            _commonModelFactory = commonModelFactory;
            _storeInformationSettings = storeInformationSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_storeInformationSettings.AllowCustomerToSelectTheme)
                return Content("");

            var model = _commonModelFactory.PrepareStoreThemeSelectorModel();
            return View(model);
        }
    }
}
