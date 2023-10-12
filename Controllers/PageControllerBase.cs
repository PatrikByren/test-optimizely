using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Nackademin23.Models.Pages;

namespace Nackademin23.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {

    }
}
