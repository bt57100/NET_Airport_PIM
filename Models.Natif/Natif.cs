using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;

namespace MyAirport.Pim.Models
{
    /// <summary>
    /// Native class for AbstractDefinition
    /// </summary>
    public class Natif : AbstractDefinition
    {
        public override void DeleteBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public override BagageDefinition GetBagage(int idBagage)
        {
            return null;
        }

        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            return null;
        }

        public override int InsertBagage(BagageDefinition bagage)
        {
            return 0;
        }

        public override BagageDefinition UpdateBagage(BagageDefinition idBagage)
        {
            return null;
        }
    }

}
