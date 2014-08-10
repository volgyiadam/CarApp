using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bootstrap;
using Bootstrap.Autofac;
using Bootstrap.Extensions.StartupTasks;
using CarAppUIMvc;

namespace CarApp.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            //var removedAssemblies = assemblies.RemoveAll(x => x.ManifestModule.Name == "CarApp.DataAccess.dll");

            Bootstrapper
                .Including.AssemblyRange(assemblies)
                .With.Autofac()
                //.And.AutoMapper()
                .And.StartupTasks()
                .Start();
        }
    }
}