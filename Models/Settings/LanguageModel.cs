namespace Nackademin23.Models.Settings
{
    public class Language
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public Language(string fullName, string shortName)
        {
            FullName = fullName;
            ShortName = shortName;
        }
    }

    public class LanguageModel
    {
        public List<Language> LanguagesList { get; set; }

        public LanguageModel()
        {
            LanguagesList = new List<Language>
            {
                new Language("Svenska", "sv"),
                new Language("Engelska", "en")
            };
        }
    }
}
