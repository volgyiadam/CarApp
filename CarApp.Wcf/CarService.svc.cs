using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarApp.Domain;
using CarApp.Domain.Entities;

namespace CarApp.Wcf
{
    public class CarService : ICarService
    {
        //private readonly Func<IEntityAccess<Car>> _carAccess;
        private readonly IEntityAccess<Car> _carAccess2;

        public CarService()
        {
            _carAccess2 = DependencyResolver.Current.GetService<IEntityAccess<Car>>();
        }

        //public CarService(Func<IEntityAccess<Car>> carAccess)
        //{
        //    _carAccess = carAccess;
        //}

        public IEnumerable<CarModel> List(int value)
        {
            //return _carAccess().List().Select(AutoMapper.Mapper.DynamicMap<CarModel>);
            return _carAccess2.List().Select(AutoMapper.Mapper.DynamicMap<CarModel>);
        }

        public CarModel Get(Guid id)
        {
            //return AutoMapper.Mapper.DynamicMap<CarModel>(_carAccess().Get(id));
            return AutoMapper.Mapper.DynamicMap<CarModel>(_carAccess2.Get(id));
        }
    }
}
