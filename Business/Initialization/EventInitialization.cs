using EPiServer.Framework.Initialization;
using EPiServer.Framework;
using Nackademin23.Models.Pages;
using EPiServer.Data;

namespace Nackademin23.Business.Initialization
{
    [InitializableModule]
    public class EventsInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var events = context.Locate.ContentEvents();
            events.PublishingContent += PublishingContent;
            //var id = events.
        }

        private void PublishingContent(object sender, ContentEventArgs e)
        {
            var page = e.Content as SitePageData;

            if (page != null)
            {
                page.XmlSitemapDate = DateTime.Now.ToString("d", Thread.CurrentThread.CurrentCulture);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
