using MyAirport.Pim.Entities;
using System.ServiceModel;

namespace ServicePim
{
    [ServiceContract]
    public interface IServicePim
    {

        [OperationContract]
        BagageDefinition GetBagageById(int idBagage);

        [OperationContract]
        [FaultContract(typeof(MultipleBagageFault))]
        BagageDefinition GetBagageByCodeIata(string codeIata);

        [OperationContract]
        int CreateBagage(BagageDefinition bag);

    }
}
