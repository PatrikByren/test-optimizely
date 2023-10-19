using Nackademin23.Business.Descriptor;
using static Nackademin23.Globals;

namespace Nackademin23.Models.Pages
{
    [ContentType(
        GUID = "EA692AB0-6219-4346-AA48-E946102A96FE",
        GroupName = GroupNames.Specialized,
        DisplayName = "Container",
        Description = "This is a container template"
    )]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(CarouselPage),
        typeof(MoviePage)}
    )]
    [ImageUrl("/gfx/page-type-thumbnail.png")]
    public class ContainerPage : PageData, IContainerIcon
    {
    }
}
