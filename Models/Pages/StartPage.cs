using EPiServer.Web;
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
            typeof(ContainerPage)
        })]
    [ImageUrl("/gfx/page-type-thumbnail.png")]
    
    public class StartPage : SitePageData
    {

        [Display(GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(CarouselPage))]
        public virtual ContentArea Carousel { get; set; }
        //[Display(GroupName = SystemTabNames.Content,
        //    Order =10,
        //    Name = "Image",
        //    Description = "This is an Image")]
        //[UIHint(UIHint.Image)]
        //public virtual ContentReference Image { get; set; }
        //[Display(GroupName = SystemTabNames.Content,
        //    Order =20)]
        //public virtual string Heading { get; set; } = string.Empty;

        //[Display(GroupName = SystemTabNames.Content,
        //Order = 30)]
        //[UIHint(UIHint.Textarea)]
        //public virtual string Preamble { get; set; } = string.Empty;
        //[Display(GroupName = SystemTabNames.Content,
        //Order = 40)]
        //public virtual XhtmlString MainBody { get; set; }
        //[ScaffoldColumn(false)]
        //public override CategoryList Category { get; set; }

    }
}
