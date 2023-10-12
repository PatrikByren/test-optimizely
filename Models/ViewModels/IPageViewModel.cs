using Nackademin23.Models.Pages;

namespace Nackademin23.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        LayoutModel Layout { get; }
        IContent Section { get; }
    }
}
