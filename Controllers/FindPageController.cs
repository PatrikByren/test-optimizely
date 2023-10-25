using EPiServer.Find;
using EPiServer.Find.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;

namespace Nackademin23.Controllers
{
    public class FindPageController : PageControllerBase<FindPage>
    {
        private readonly IContentLoader _contentLoader;

        public FindPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(FindPage currentPage, string query)
        {
            var model = new FindPageViewModel(currentPage, query);
            if(string.IsNullOrEmpty(query))
                return View(model);

            var unifiedSearch = SearchClient.Instance.UnifiedSearchFor(query);
            model.Results = unifiedSearch.GetResult();
            return View(model);
        }
    }
}