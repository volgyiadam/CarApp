using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;

namespace CarApp.Wcf.WireUp
{
    public class GlobalModule : IStartupTask
    {
        public void Run()
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver((IContainer)Bootstrapper.Container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)Bootstrapper.Container);
        }

        public void Reset() { }
    }
}