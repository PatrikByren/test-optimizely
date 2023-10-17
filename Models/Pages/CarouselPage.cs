using EPiServer.SpecializedProperties;
using EPiServer.Web;
using static Nackademin23.Globals;
using System.ComponentModel.DataAnnotations;

namespace Nackademin23.Models.Pages
{

    [ContentType(
      GUID = "391D703F-6C14-4FD1-9CE9-B1EF89004E85",
      GroupName = GroupNames.Specialized,
      DisplayName = "Carousel",
      Description = "This is a carousel template"
    )]
    [AvailableContentTypes(Availability.None)]
    [ImageUrl("/gfx/page-type-thumbnail.png")]
    public class CarouselPage : SitePageData 
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10,
            Name = "Image",
            Description = "This is an image"
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        [CultureSpecific]
        public virtual XhtmlString Text { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40
        )]
        [CultureSpecific]
        public virtual LinkItem Link { get; set; }
    }
}
