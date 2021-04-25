using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //This will restrict home page too. So apply anonymous attribute on home page controller to
            //allow anonymous user
            filters.Add(new AuthorizeAttribute());

            //disable non SSL i.e. HTTP browsing.
            //Currently web app is accessible on both:
            //https://localhost:44305/ & http://localhost:63700/
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
