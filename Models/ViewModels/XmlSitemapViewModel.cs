using Nackademin23.Models.Pages;

namespace Nackademin23.Models.ViewModels
{
    public class XmlSitemapViewModel : PageViewModel<XmlSitemap>
    {
        public IEnumerable<SitePageData> Descendants { get; set; }

        public XmlSitemapViewModel(XmlSitemap currentPage) : base(currentPage)
        {
        }
    }
}
