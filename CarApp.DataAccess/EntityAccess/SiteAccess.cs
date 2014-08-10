using CarApp.DataAccess.Entities; 
using CarApp.Domain;
using CarApp.Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace CarApp.DataAccess.EntityAccess
{
    public class SiteAccess : IEntityAccess<Site>
    {

        private readonly Func<ISession> _session;

        public SiteAccess(Func<ISession> session)
        {
            _session = session;
        }
        public IEnumerable<Site> List()
        {
            return _session().Query<SiteEntity>().Select(AutoMapper.Mapper.DynamicMap<Site>).ToList();
        }

        public Site Get(Guid id)
        {
            return AutoMapper.Mapper.DynamicMap<Site>(_session().Get<SiteEntity>(id));
        }

        public void Save(Site entity)
        {
            _session().Save(AutoMapper.Mapper.DynamicMap<SiteEntity>(entity));
            return;
        }

        public void Delete(Guid id)
        {
            _session().Delete(_session().Get<SiteEntity>(id));
            return;
        }

        public void Update(Site entity)
        {
            _session().Update(AutoMapper.Mapper.DynamicMap<SiteEntity>(entity));
            return;
        }
    }
}
