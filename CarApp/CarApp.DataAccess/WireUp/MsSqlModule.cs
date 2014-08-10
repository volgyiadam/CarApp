using System.Configuration;
using Autofac;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace CarApp.DataAccess.WireUp
{
    public class MsSqlModule : Module, IStartupTask
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            builder.Register(context => Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<MsSqlModule>())
                .BuildConfiguration()
                ).As<Configuration>().SingleInstance();

            builder.Register(context => context.Resolve<Configuration>().BuildSessionFactory()).As<ISessionFactory>().SingleInstance();

            builder.Register(context => context.Resolve<ISessionFactory>().OpenSession())
                .InstancePerLifetimeScope()
                .OnActivated(args => args.Instance.BeginTransaction())
                .OnRelease(session => session.Transaction.Commit())
                .As<ISession>();

            builder.Register(context => context.Resolve<ISessionFactory>().OpenStatelessSession())
                .InstancePerLifetimeScope()
                .As<IStatelessSession>();
        }

        public void Run()
        {
            var container = ((IContainer)Bootstrapper.Container);
            var config = container.Resolve<Configuration>();

            //var schemaExport = new SchemaExport(config);
            //schemaExport.Execute(true, true, false);

            var schemaUpdate = new SchemaUpdate(config);
            schemaUpdate.Execute(true, true);
        }

        public void Reset() { }
    }
}
