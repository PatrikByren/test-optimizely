using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nackademin23.Business.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string Action(this IHtmlHelper helper, string controller, string action)
        {
            return string.Format("{0}{1}", controller, action);
        }
    }
}
