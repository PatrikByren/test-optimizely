using Microsoft.AspNetCore.Mvc;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;

namespace Nackademin23.Controllers
{
    public class MoviePageController : PageControllerBase<MoviePage>
    {
        private readonly IContentLoader _contentLoader;

        public MoviePageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(MoviePage currentPage)
        {
            var model = new MoviePageViewModel(currentPage);
            return View(model);
        }
    }
}
