using Bootstrap.Extensions.StartupTasks;
using CarApp.DataAccess.Entities;
using CarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.DataAccess.WireUp
{
    public class AutoMapperModule : IStartupTask
    {
        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            AutoMapper.Mapper.CreateMap<CarEntity, Car>()
                .ForMember(x => x.TelepHelyAddress, y => y.MapFrom(z => z.Site != null ? z.Site.Address : ""))
                .ForMember(a => a.TelepId, b => b.MapFrom(c => c.Site != null ? c.Site.Id : Guid.Empty));
                
        }
    }
}
