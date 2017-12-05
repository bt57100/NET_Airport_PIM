using System.Collections.Generic;
using System.ServiceModel;
using MyAirport.Pim.Entities;

namespace ServicePim
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServicePim : IServicePim
    {
        int NbAppelInstance { get; set; }
        public int NbAppelTotale { get; set; }           

        public int CreateBagage(BagageDefinition bag)
        {
            NbAppelTotale++;
            this.NbAppelInstance++;
            return MyAirport.Pim.Models.Factory.Model.InsertBagage(bag);
        }
        
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

        public BagageDefinition GetBagageById(int idBagage)
        {
            NbAppelTotale++;
            this.NbAppelInstance++;
            return MyAirport.Pim.Models.Factory.Model.GetBagage(idBagage);
        }
    }
}
