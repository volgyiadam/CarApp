using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Domain.Entities
{
    public class Site : Entity
    {
        public string ZipCode { get; set; }
        public string Address { get; set; }

        public List<Car> Autok { get; set; }
    }
}
