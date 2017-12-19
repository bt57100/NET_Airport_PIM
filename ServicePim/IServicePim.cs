using MyAirport.Pim.Entities;
using System.ServiceModel;

namespace ServicePim
{
    [ServiceContract]
    public interface IServicePim
    {
        /// <summary>
        /// Get bagage by ID_BAGAGE
        /// </summary>
        /// <param name="idBagage"></param>
        /// <returns>the corresponding bagage</returns>
        [OperationContract]
        BagageDefinition GetBagageById(int idBagage);

        /// <summary>
        /// Update bagage by ID_BAGAGE
        /// </summary>
        /// <param name="bagage"></param>
        /// <returns>the bagage modified</returns>
        [OperationContract]
        BagageDefinition UpdateBagage(BagageDefinition bagage);
        
        /// <summary>
        /// Get bagage by CODE_IATA ____<6values>00
        /// </summary>
        /// <param name="codeIata"></param>
        /// <returns>the corresponding bagage</returns>
        [OperationContract]
        [FaultContract(typeof(MultipleBagageFault))]
        BagageDefinition GetBagageByCodeIata(string codeIata);

        /// <summary>
        /// Create a new bagage
        /// </summary>
        /// <param name="bag"></param>
        /// <returns>the ID_BAGAGE of the bagage created</returns>
        [OperationContract]
        int CreateBagage(BagageDefinition bag);

    }
}
