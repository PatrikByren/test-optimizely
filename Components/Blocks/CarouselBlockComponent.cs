using EPiServer.Web;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Nackademin23.Models.Blocks;
using Nackademin23.Models.Pages;
using Nackademin23.Models.ViewModels;

namespace Nackademin23.Components.Blocks
{
    public class CarouselBlockComponent : AsyncBlockComponent<CarouselBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(CarouselBlock currentContent)
        {
            var model = new CarouselBlockViewModel();
            var i = 0;

            foreach(var page in currentContent.Carousel.FilteredItems.Select(x => x.LoadContent()))
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
            return View("~/components/blocks/default.cshtml", model);
        }
    }
}
