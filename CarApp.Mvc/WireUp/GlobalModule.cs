using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;

namespace CarApp.Mvc.WireUp
{
    public class GlobalModule : Module, IStartupTask
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterApiControllers(typeof (GlobalModule).Assembly).InstancePerDependency();
            //builder.RegisterControllers(typeof(GlobalModule).Assembly).InstancePerDependency();
            builder.RegisterControllers(typeof(GlobalModule).Assembly).InstancePerRequest();

            builder.RegisterFilterProvider();

        }

        public void Run()
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver((IContainer)Bootstrapper.Container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)Bootstrapper.Container);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        public void Reset() { }
    }
}