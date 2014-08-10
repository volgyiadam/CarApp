using System;
using FluentNHibernate.Mapping;

namespace CarApp.DataAccess.Entities
{
    public class CarEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string LicencePlate { get; set; }
    }

    public class CarEntityMap : ClassMap<CarEntity>
    {
        public CarEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.LicencePlate);
        }
    }
}
