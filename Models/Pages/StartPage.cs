using System.ComponentModel.DataAnnotations;
using static Nackademin23.Globals;

namespace Nackademin23.Models.Pages
{

    [ContentType(GUID = "02E5447A-5081-437A-891E-DF55CF4D5801", GroupName = GroupNames.Specialized)]
    
    public class StartPage : SitePageData
    {
        [Display(GroupName = SystemTabNames.Content)]
        public virtual string Heading { get; set; } = string.Empty;
    }
}
