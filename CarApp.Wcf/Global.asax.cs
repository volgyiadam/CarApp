using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using Bootstrap;
using Bootstrap.Autofac;
using Bootstrap.Extensions.StartupTasks;

namespace CarApp.Wcf
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            Bootstrapper
                .Including.AssemblyRange(assemblies)
                .With.Autofac()
                //.And.AutoMapper()
                .And.StartupTasks()
                .Start();
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{

        //}

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{

        //}

        //protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}

        //protected void Application_Error(object sender, EventArgs e)
        //{

        //}

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}