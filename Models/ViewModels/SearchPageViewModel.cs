using Nackademin23.Models.Pages;

namespace Nackademin23.Models.ViewModels
{
    public class SearchPageViewModel : PageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        public List<MoviesViewModel.Search> Movies { get; set; }

        public MovieViewModel.Root Movie { get; set; }
    }
}
