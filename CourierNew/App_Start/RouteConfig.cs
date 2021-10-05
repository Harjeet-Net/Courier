using Microsoft.AspNet.FriendlyUrls;
using System.Web.Routing;


namespace UI
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            FriendlyUrlSettings settings = new FriendlyUrlSettings
            {
                AutoRedirectMode = RedirectMode.Permanent
            };
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("", "Home/{id}", "~/Reports/CustomerCandidateReport");
            routes.MapPageRoute("", "Home/{id}", "~/Reports");
         
        }
    }
}