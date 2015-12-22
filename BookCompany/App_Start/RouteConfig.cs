using System.Web.Mvc;
using System.Web.Routing;

namespace BookCompanyManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CreatePaperMakingOrder",
                url: "PapermakingOrders/Create/{papermillid}/{paperbrandid}",
                defaults: new { controller = "PapermakingOrders", action = "Create", papermillid = UrlParameter.Optional, paperbrandid = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BookPrintOrders", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
