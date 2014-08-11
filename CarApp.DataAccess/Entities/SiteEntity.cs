using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.DataAccess.Entities
{
    public class SiteEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Address { get; set; }
        //public virtual IList<CarEntity> Autok { get; set; }
    }

    public class SiteEntityMap : ClassMap<SiteEntity>
    {
        public SiteEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.ZipCode);
            Map(x => x.Address);
            //HasMany(x => x.Autok).ForeignKeyConstraintName("Site");
        }

    }
}
