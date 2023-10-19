using Nackademin23.Models.Pages;

namespace Nackademin23.Models.ViewModels
{
    public class StartPageViewModel : PageViewModel<StartPage>
    {
        public StartPageViewModel(StartPage currentPage) : base(currentPage)
        {

        }
        public IEnumerable<MoviePage> Movies { get; set; }
    }
}