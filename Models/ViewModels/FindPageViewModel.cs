using EPiServer.Find.UnifiedSearch;
using Nackademin23.Models.Pages;

namespace Nackademin23.Models.ViewModels
{
    public class FindPageViewModel : PageViewModel<FindPage>
    {
        public FindPageViewModel(FindPage currentPage, string searchQuery) : base(currentPage)
        {
            SearchQuery = searchQuery;
        }
        public string SearchQuery { get; set; }
        public UnifiedSearchResults Results { get; set; }    
    }
}
