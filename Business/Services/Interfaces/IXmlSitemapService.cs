using Nackademin23.Models.Pages;

namespace Nackademin23.Business.Services.Interfaces
{
    public interface IXmlSitemapService
    {
        IEnumerable<SitePageData> Descendants(XmlSitemap currentPage);
    }
}
