using Autofac;
using CarApp.DataAccess.EntityAccess;
using CarApp.Domain;

namespace CarApp.DataAccess.WireUp
{
    public class EntityAccesses : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarAccess>().As<IEntityAccess<Domain.Entities.Car>>().InstancePerLifetimeScope();
        }
    }
}
