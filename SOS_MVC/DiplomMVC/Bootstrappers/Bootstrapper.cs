using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DiplomMVC.Bootstrappers.Registrators;

namespace DiplomMVC.Bootstrappers
{
    public class Bootstrapper : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundlesRegistrator.Register(BundleTable.Bundles);
        }
    }
}