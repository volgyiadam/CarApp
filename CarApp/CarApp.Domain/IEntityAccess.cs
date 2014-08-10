using System;
using System.Collections.Generic;
using CarApp.Domain.Entities;

namespace CarApp.Domain
{
    public interface IEntityAccess<T>
        where T : Entity
    {
        IEnumerable<T> List();
        T Get(Guid id);

        void Save(T entity);
        void Delete(Guid id);
    }
}
