using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using Nackademin23.Business.Extensions;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;

namespace Nackademin23.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
     private readonly IContentLoader _contentLoader;   

        public StartPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(StartPage currentPage)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            var settingsPages = new List<SettingsPage>();
            startPage.GetDescendantsOfType(settingsPages);
            var settingsPage = settingsPages.FirstOrDefault();
            var model = new StartPageViewModel(currentPage);

            if (settingsPage != null)
            {
                var parent = settingsPage.MoviesContainer;

                if (parent != null)
                {
                    model.Movies = _contentLoader.GetChildren<MoviePage>(parent);
                }
            }

            return View(model);
        }
    }
}
