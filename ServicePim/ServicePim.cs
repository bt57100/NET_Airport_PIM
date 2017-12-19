using System.Collections.Generic;
using System.ServiceModel;
using MyAirport.Pim.Entities;

namespace ServicePim
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServicePim : IServicePim
    {
        int NbAppelInstance { get; set; }
        public int NbAppelTotale { get; set; }           

        /// <summary>
        /// Create a new bagage
        /// </summary>
        /// <param name="bag"></param>
        /// <returns>the ID_BAGAGE of the bagage created</returns>
        public int CreateBagage(BagageDefinition bag)
        {
            int id = 0;
            NbAppelTotale++;
            this.NbAppelInstance++;
            id = MyAirport.Pim.Models.Factory.Model.InsertBagage(bag);
            if(id == 0)
            {
                throw new FaultException("This company code iata does not exist !");
            }
            return id;
        }
        
        /// <summary>
        /// Get bagage by CODE_IATA ____<6values>00
        /// </summary>
        /// <param name="codeIata"></param>
        /// <returns>the corresponding bagage</returns>
        public BagageDefinition GetBagageByCodeIata(string codeIata)
        {
            NbAppelTotale++;
            this.NbAppelInstance++;
            List<BagageDefinition> list = MyAirport.Pim.Models.Factory.Model.GetBagage(codeIata);
            if (list != null)
            {
                if (list.Count == 1)
                {
                    return list[0];
                }
                else if (list.Count > 1)
                {
                    MultipleBagageFault bagages = new MultipleBagageFault();
                    bagages.CodeIata = codeIata;
                    bagages.ListBagages = list;
                    bagages.Message = "Il existe " + list.Count + " bagages avec le code Iata demandé";
                    throw new FaultException<MultipleBagageFault>(bagages);
                } else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get bagage by ID_BAGAGE
        /// </summary>
        /// <param name="idBagage"></param>
        /// <returns>the corresponding bagage</returns>
        public BagageDefinition GetBagageById(int idBagage)
        {
            NbAppelTotale++;
            this.NbAppelInstance++;
            return MyAirport.Pim.Models.Factory.Model.GetBagage(idBagage);
        }

        /// <summary>
        /// Update bagage by ID_BAGAGE
        /// </summary>
        /// <param name="bagage"></param>
        /// <returns>the bagage modified</returns>
        public BagageDefinition UpdateBagage(BagageDefinition bagage)
        {
            NbAppelTotale++;
            this.NbAppelInstance++;
            return MyAirport.Pim.Models.Factory.Model.UpdateBagage(bagage);
        }
    }
}
