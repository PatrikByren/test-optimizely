using Nackademin23.Models.Pages;

namespace Nackademin23.Models.ViewModels
{
    public class CarouselViewPageModel
    {
        public string Active { get; set; }
        public string AriaCurrent { get; set; }
        public int DataBsSlideTo { get; set; }
        public string AriaLabel { get; set; }
        public CarouselPage Page { get; set; }
    }
}
