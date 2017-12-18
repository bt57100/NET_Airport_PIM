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
        BagageDefinition UpdateBagage(BagageDefinition bagage);

        [OperationContract]
        [FaultContract(typeof(MultipleBagageFault))]
        BagageDefinition GetBagageByCodeIata(string codeIata);

        [OperationContract]
        int CreateBagage(BagageDefinition bag);

    }
}
