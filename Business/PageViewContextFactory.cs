using EPiServer.Data;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;
using System.Security.Principal;

namespace Nackademin23.Business
{
    [ServiceConfiguration]
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;
        private readonly ILogger<PageViewContextFactory> _logger;

        public PageViewContextFactory(IContentLoader contentLoader, ILogger<PageViewContextFactory> logger)
        {
            _contentLoader = contentLoader;
            _logger = logger;
        }

        public virtual LayoutModel CreateLayoutModel(ContentReference currentContentLink, HttpContext httpContext)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;

            if (currentContentLink.CompareToIgnoreWorkID(startPageContentLink))
            {
                startPageContentLink = currentContentLink;
            }

            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);

            return new LayoutModel
            {
                StartPage = startPage,
                SettingsPage = GetSettingsPage()
            };
        }

        private SettingsPage GetSettingsPage()
        {
            var settingsPage = new SettingsPage();
            var startPage = SiteDefinition.Current.StartPage;

            if (startPage != ContentReference.EmptyReference)
            {
                var settingsPages = _contentLoader.GetChildren<SettingsPage>(startPage);

                if (settingsPages.Any())
                {
                    settingsPage = settingsPages.FirstOrDefault();
                }
                else
                {
                    _logger.LogError("Det finns ingen Inställningssida skapad under ContentReference.StartPage");
                }
            }
            else
            {
                _logger.LogError("SiteDefinition.Current.StartPage.ProviderName is null or empty.");
            }

            return settingsPage;
        }
    }
}
