using Autofac;
using CarApp.DataAccess.InMemory.EntityAccess;
using CarApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.DataAccess.InMemory.WireUp
{
    public class EntityAccesses : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarAccess>().As<IEntityAccess<Domain.Entities.Car>>().InstancePerLifetimeScope();
        }
    }
}
