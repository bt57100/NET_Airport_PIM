using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;

namespace MyAirport.Pim.Models
{
    public class Natif : AbstractDefinition
    {
        public override void DeleteBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public override Entities.BagageDefinition GetBagage(int idBagage)
        {
            return null;
        }

        public override List<Entities.BagageDefinition> GetBagage(string codeIataBagage)
        {
            return null;
        }

        public override int InsertBagage(BagageDefinition bagage)
        {
            return 0;
        }

        public override BagageDefinition UpdateBagage(int idBagage)
        {
            return null;
        }
    }

}
