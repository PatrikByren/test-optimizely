namespace Nackademin23.Models.TranslationsModel
{
    public class GenreTranslations
    {
        public Dictionary<string, string[]> genreTranslations { get; }

        public GenreTranslations()
        {
            genreTranslations = new Dictionary<string, string[]>
            {
                { "sv", new string[] { "Skräck", "Komedi", "Thriller", "Mysterium", "Fantasy", "Action", "Drama", "Sci-Fi" } },
                { "en", new string[] { "Horror", "Comedy", "Thriller", "Mystery", "Fantasy", "Action", "Drama", "Sci-Fi" } }
            };
        }

        public List<string> GetGenres(string languageCode)
        {
            List<string> genres = new List<string>();

            if (genreTranslations.TryGetValue(languageCode.ToLower(), out var translatedGenres))
            {
                genres.AddRange(translatedGenres);
            }
            else
            {
                // Om översättning saknas, använd engelska som standard
                if (genreTranslations.TryGetValue("en", out var defaultGenres))
                {
                    genres.AddRange(defaultGenres);
                }
            }

            return genres;
        }

    }
}

