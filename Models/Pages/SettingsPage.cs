using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static Nackademin23.Globals;

namespace Nackademin23.Models.Pages
{

    [ContentType(
        GUID = "357319DE-8302-4203-BF2E-2806FAFDF797", 
        GroupName = GroupNames.Specialized)]
    [ImageUrl("/gfx/page-type-thumbnail.png")]
    
    public class SettingsPage : SitePageData
    {
        [Display(GroupName = SystemTabNames.Content,
            Order =10)]
        public virtual PageReference MoviesContainer { get; set; }

    }
}
