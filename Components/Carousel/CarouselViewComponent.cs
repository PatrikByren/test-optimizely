using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;

namespace Nackademin23.Components.Carousel
{
    public class CarouselViewComponent : ViewComponent
    {
        private readonly IContentLoader _contentLoader;

        public CarouselViewComponent(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IViewComponentResult Invoke()
        {
            var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
            var model = new CarouselViewModel();
            var i = 0;

            foreach(var page in startPage.Carousel.FilteredItems.Select(x => x.LoadContent()))
            {
                if (page is CarouselPage)
                {
                    var pageModel = new CarouselViewPageModel();
                    if(i == 0)
                    {
                        pageModel.Active = "active";
                        pageModel.AriaCurrent = "true";
                    }
                    else
                    {
                        pageModel.Active = null;
                        pageModel.AriaCurrent = null;
                    }
                    pageModel.DataBsSlideTo = i++;
                    pageModel.AriaLabel = string.Format($"Slide {i}");
                    pageModel.Page = page as CarouselPage;

                    model.Pages.Add(pageModel);
                }
            }
            return View("~/components/carousel/default.cshtml", model);
        }
    }
}
