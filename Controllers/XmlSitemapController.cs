using Microsoft.AspNetCore.Mvc;
using Nackademin23.Business.Services.Interfaces;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;

namespace Nackademin23.Controllers
{
    public class XmlSitemapController : PageControllerBase<XmlSitemap>
    {
        private IXmlSitemapService _xmlSitemapService;

        public XmlSitemapController(IXmlSitemapService xmlSitemapService)
        {
            _xmlSitemapService = xmlSitemapService;
        }

        public ActionResult Index(XmlSitemap currentPage)
        {
            var model = new XmlSitemapViewModel(currentPage)
            {
                Descendants = _xmlSitemapService.Descendants(currentPage)
            };

            return View(model);
        }
    }
}
