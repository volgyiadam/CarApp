using System;
using System.Collections.Generic;
using System.Linq;
using CarApp.DataAccess.Entities;
using CarApp.Domain;
using CarApp.Domain.Entities;
using NHibernate;
using NHibernate.Linq;


namespace CarApp.DataAccess.EntityAccess
{
    public class CarAccess : IEntityAccess<Car>
    {
        private readonly Func<ISession> _session;

        public CarAccess(Func<ISession> session)
        {
            _session = session;
        }

        public IEnumerable<Car> List()
        {
            return _session().Query<CarEntity>().Select(AutoMapper.Mapper.DynamicMap<Car>).ToList();
        }

        public Car Get(Guid id)
        {
            return AutoMapper.Mapper.DynamicMap<Car>(_session().Get<CarEntity>(id));
        }

        public void Save(Car entity)
        {
            _session().Save(AutoMapper.Mapper.DynamicMap<CarEntity>(entity));
        }

        public void Delete(Guid id)
        {
            _session().Delete(_session().Get<CarEntity>(id));
        }


        public void Update(Car entity)
        {
            _session().Update(new CarEntity { Id = entity.Id, LicencePlate = entity.LicencePlate, Site = _session().Get<SiteEntity>(entity.TelepId) });
        }
    }
}
