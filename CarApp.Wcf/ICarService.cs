using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CarApp.Wcf
{
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        IEnumerable<CarModel> List(int value);

        [OperationContract]
        CarModel Get(Guid id);
    }


    [DataContract]
    public class CarModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string LicencePlate { get; set; }
    }
}
