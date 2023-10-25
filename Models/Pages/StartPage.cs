using EPiServer.Web;
using Nackademin23.Models.Blocks;
using System.ComponentModel.DataAnnotations;
using static Nackademin23.Globals;

namespace Nackademin23.Models.Pages
{

    [ContentType(GUID = "02E5447A-5081-437A-891E-DF55CF4D5801", 
        GroupName = GroupNames.Specialized,
        DisplayName ="Start",
        Description ="This is a startpage")]
    [AvailableContentTypes(Availability.Specific,
        Include = new[]
        {
            typeof(SettingsPage),
            typeof(ContainerPage),
            typeof(SearchPage),
            typeof(XmlSitemap),
            typeof(FindPage)
        })]
    [ImageUrl("/gfx/page-type-thumbnail.png")]
    
    public class StartPage : SitePageData
    {

        [Display(GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(CarouselPage), typeof(CarouselBlock))]
        public virtual ContentArea Carousel { get; set; }
        [Display(GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual XhtmlString Text {  get; set; }
    }
}
