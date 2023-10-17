using EPiServer.Web;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Org.BouncyCastle.Asn1.X509.Qualified;
using EPiServer.ServiceLocation;
using Nackademin23.Models.Settings;
using Nackademin23.Models.TranslationsModel;
using EPiServer.Globalization;
using System.Globalization;
using EPiServer.Security;
using EPiServer.Cms.UI.Settings.Controllers.Internal;
using EPiServer.Shell.UserMembership.Internal;
using EPiServer.Data;
using EPiServer.Personalization.VisitorGroups.Criteria;
using EPiServer.Shell.Profile;
using EPiServer.Cms.UI.AspNetIdentity;

namespace Nackademin23.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(InitializationModule))]
    public class CategoryInitialization : IInitializableModule
    {

        public void Initialize(InitializationEngine context)
        {
            CreateCategories();
        }
        private void CreateCategories()
        {

            GenreTranslations genreGenerator = new GenreTranslations();
            LanguageModel language = new LanguageModel();
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var root = categoryRepository.GetRoot();
            

            foreach (var item in language.LanguagesList)
            {
                var categoryTitle = $"Film genres ({item.ShortName})";
                var check = categoryRepository.Get(categoryTitle);
                if (CategoryByLanguageChecker(categoryRepository, categoryTitle) == null)
                {
                    Category systemCategory = CreateCategory(root, categoryTitle);
                    categoryRepository.Save(systemCategory);
                }
                var thisCategory = categoryRepository.Get(categoryTitle);
                var list = thisCategory.Categories;
                foreach (var genre in genreGenerator.GetGenres(item.ShortName))
                {
                    if (!list.Any(x => x.Name == genre))
                    {
                        var category = new Category(thisCategory, genre)
                        {
                            
                            Available = true,
                            Description = genre,
                            Selectable = true
                        };

                        categoryRepository.Save(category);
                    }
                }
            }
        }

        private static Category CreateCategory(Category root, string categoryTitle)
        {
            return new Category(root, categoryTitle)
            {
                Available = true,
                Description = categoryTitle,
                Selectable = false
            };
        }

        private static Category CategoryByLanguageChecker(CategoryRepository categoryRepository, string categoryTitle)
        {
            var test = categoryRepository.Get(categoryTitle);
            return test;
        }

        public void Uninitialize(InitializationEngine context)
        { 
        
        }
    }
}



