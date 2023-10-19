using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using Nackademin23.Business.Extensions;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;
using Newtonsoft.Json;

namespace Nackademin23.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IContentRepository _contentRepository;

        public SearchPageController(IContentLoader contentLoader, IContentRepository contentRepository)
        {
            _contentLoader = contentLoader;
            _contentRepository = contentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync(SearchPage currentPage, string query)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.omdbapi.com/?apikey=ab22c7a5&s={query}");
            var response = await client.SendAsync(request);
            var status = response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var model = new SearchPageViewModel(currentPage);

            if (status.IsSuccessStatusCode)
                {
                   var result = response.Content.ReadAsStringAsync();
                   var movies = JsonConvert.DeserializeObject<MoviesViewModel.Root>(result.Result);

                if (movies != null)
                {
                    var parent = GetParent();

                    if (parent != null)
                    {
                        var filteredMovies = new List<MoviesViewModel.Search>();

                        foreach (var item in movies.Search.OrderBy(x => x.Year).ToList())
                        {
                            if (!MovieExists(parent, item.ImdbID))
                            {
                                filteredMovies.Add(item);
                            }
                        }

                        model.Movies = filteredMovies;
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddAsync(SearchPage currentPage, string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.omdbapi.com/?apikey=ab22c7a5&i={id}");
            var response = await client.SendAsync(request);
            var status = response.EnsureSuccessStatusCode();
            var model = new SearchPageViewModel(currentPage);

            if (status.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                var movie = JsonConvert.DeserializeObject<MovieViewModel.Root>(result.Result);

                if (movie != null)
                {
                    var parent = GetParent();

                    if (parent != null)
                    {
                        var page = _contentRepository.GetDefault<MoviePage>(parent);

                        page.Name = movie.Title;
                        page.Title = movie.Title;
                        page.Poster = movie.Poster != null ? movie.Poster : "~/static/img/default-poster.jpg";
                        page.Year = movie.Year;
                        page.ImdbRating = movie.ImdbRating;
                        page.ImdbID = movie.ImdbID;
                        page.Genre = movie.Genre;
                        page.Plot = movie.Plot;

                        _contentRepository.Save(page, EPiServer.DataAccess.SaveAction.Publish);
                    }
                }
            }

            return LocalRedirect("/");
        }
        private bool MovieExists(ContentReference parent, string imdbID)
        {
            var child = _contentLoader.GetChildren<MoviePage>(parent).Where(x => x.ImdbID == imdbID).FirstOrDefault();

            if (child == null)
            {
                return false;
            }

            return true;
        }
        public ContentReference GetParent()
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            var settingsPages = new List<SettingsPage>();
            startPage.GetDescendantsOfType(settingsPages);
            var settingsPage = settingsPages.FirstOrDefault();

            if (settingsPage != null)
            {
                var parent = settingsPage.MoviesContainer;

                if (parent != null)
                {
                    return parent;
                }
            }

            return null;
        }
    }
}
