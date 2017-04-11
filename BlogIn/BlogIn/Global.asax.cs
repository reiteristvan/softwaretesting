using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlogIn.Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace BlogIn
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer container = new UnityContainer();
            UnityConfiguration.RegisterDependencies(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
