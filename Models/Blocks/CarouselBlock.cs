using Nackademin23.Models.Pages;
using static Nackademin23.Globals;
using System.ComponentModel.DataAnnotations;

namespace Nackademin23.Models.Blocks
{
    [ContentType(
        GUID = "E9BE1743-4E28-4C24-8A06-094F4792A9DA",
        GroupName = GroupNames.Specialized,
        DisplayName = "Carousel Block",
        Description = "This is a carousel block template"
    )]
    [ImageUrl("/gfx/page-type-thumbnail.png")]
    public class CarouselBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [AllowedTypes(typeof(CarouselPage))]
        public virtual ContentArea Carousel { get; set; }
    }
}
