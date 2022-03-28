using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace dotnetcoresoapcore.Models
{
    [ServiceContract(Name = "ProductService", Namespace = "hserusaoldc.SoapCore.Sample"), XmlSerializerFormat]
    public interface IProductService
    {
        [OperationContract]
        bool Create(Product product);

        [OperationContract]
        bool Update(Product product);

        [OperationContract]
        bool Delete(Guid id);

        [OperationContract]
        Product[] Get();
    }
}
