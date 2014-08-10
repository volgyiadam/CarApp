using CarApp.Domain;
using CarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarApp.DataAccess.InMemory.EntityAccess
{
    public class CarAccess : IEntityAccess<Car>
    {

        static List<Car> _carsList = new List<Car>();
                
        public IEnumerable<Car> List()
        {
            return _carsList.ToList();
        }

        public Car Get(Guid id)
        {
            return _carsList.First(x => x.Id == id);
        }

        public void Save(Car entity)
        {
            _carsList.Add(new Car() { Id = Guid.NewGuid(), LicencePlate = entity.LicencePlate });
        }

        public void Delete(Guid id)
        {
            _carsList.RemoveAll(x => x.Id == id);
        }


        public void Update(Car entity)
        {
            var car = _carsList.Find(x => x.Id == entity.Id);
            car.LicencePlate = entity.LicencePlate;
        }
    }
}
