using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Nackademin23.Models.Pages;

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
        public static IEnumerable<SitePageData> ToSitePageData(this IEnumerable<ContentReference> contentReferences)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var pages = new List<SitePageData>();

            foreach (var contentReference in contentReferences)
            {
                var contentRef = contentRepository.Get<PageData>(contentReference);

                if (contentRef is SitePageData)
                {
                    pages.Add(contentRepository.Get<SitePageData>(contentReference));
                }
            }

            return pages;
        }
        public static string GetExternalUrl(this IContent content)
        {
            var internalUrl = UrlResolver.Current.GetUrl(content.ContentLink);

            if (internalUrl != null)
            {
                var url = new UrlBuilder(internalUrl);
                //EPiServer.Global.UrlRewriteProvider.ConvertToExternal(url, null, Encoding.UTF8);
                var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

                return friendlyUrl;
            }

            return null;
        }

        public static string Url(this string url)
        {
            return UrlResolver.Current.GetUrl(url);
        }
    }
}
