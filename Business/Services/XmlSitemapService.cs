using Nackademin23.Business.Extensions;
using Nackademin23.Business.Services.Interfaces;
using Nackademin23.Models.Pages;

namespace Nackademin23.Business.Services
{
    public class XmlSitemapService : IXmlSitemapService
    {
        private IContentLoader _contentLoader;

        public XmlSitemapService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IEnumerable<SitePageData> Descendants(XmlSitemap currentPage)
        {
            var startPage = _contentLoader.GetAncestors(currentPage.ContentLink).FirstOrDefault(x => x is StartPage) as PageData;
            var descendants = Enumerable.Empty<SitePageData>();

            if (startPage != null)
            {
                descendants = _contentLoader.GetDescendents(startPage.ContentLink).ToSitePageData().Where(x => !(x is XmlSitemap)
                && !(x is ContainerPage)); //&& !(x is IHideSitemap))  ;
            }

            return descendants;
        }
    }
}
