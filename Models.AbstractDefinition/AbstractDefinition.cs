using MyAirport.Pim.Entities;
using System.Collections.Generic;

namespace MyAirport.Pim.Models
{
    /// <summary>
    /// Abstract class AbstractDefinition
    /// It contains the least requirement of a pim system
    /// </summary>
    public abstract class AbstractDefinition
    {
        public abstract BagageDefinition GetBagage(int idBagage);
        public abstract List<BagageDefinition> GetBagage(string codeIataBagage);
        public abstract BagageDefinition UpdateBagage(BagageDefinition idBagage);
        public abstract int InsertBagage(BagageDefinition bagage);
        public abstract void DeleteBagage(int idBagage);
    }
}

