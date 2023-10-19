using EPiServer.ServiceLocation;

namespace Nackademin23.Business.Extensions
{
    public static class PageDataExtensions
    {
        public static void GetDescendantsOfType<T>(this PageData page, ICollection<T> descendants) where T : class
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var children = contentRepository.GetChildren<PageData>(page.ContentLink);

            foreach (var child in children)
            {
                if (child is T)
                {
                    descendants.Add(child as T);
                }

                GetDescendantsOfType(child, descendants);
            }
        }
    }
}
