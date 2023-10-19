using EPiServer.Web;
using Nackademin23.Business.Descriptor;
using static Nackademin23.Globals;
using System.ComponentModel.DataAnnotations;

namespace Nackademin23.Models.Pages
{
    [ContentType(
        GUID = "AE24E1A5-5E41-4CF4-8B73-8DD6A966ACD4",
        GroupName = GroupNames.Specialized,
        DisplayName = "Movie",
        Description = "This is a movie template"
    )]
    [AvailableContentTypes(Availability.None)]
    public class MoviePage : SitePageData, ICarouselIcon
    {
        [Display(
            Name = "Poster",
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        public virtual string Poster { get; set; } = string.Empty;

        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        public virtual string Title { get; set; } = string.Empty;


        [Display(
            Name = "Plot",
            GroupName = SystemTabNames.Content,
            Order = 25
        )]
        [UIHint(UIHint.Textarea)]
        public virtual string Plot { get; set; } = string.Empty;

        [Display(
            Name = "Year",
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        public virtual string Year { get; set; } = string.Empty;

        [Display(
            Name = "Genre",
            GroupName = SystemTabNames.Content,
            Order = 40
        )]
        public virtual string Genre { get; set; } = string.Empty;

        [Display(
            Name = "IMDB rating",
            GroupName = SystemTabNames.Content,
            Order = 50
        )]
        public virtual string ImdbRating { get; set; } = string.Empty;

        [Display(
            Name = "IMDB id",
            GroupName = SystemTabNames.Content,
            Order = 60
        )]
        [Editable(false)]
        public virtual string ImdbID { get; set; } = string.Empty;
    }
}
