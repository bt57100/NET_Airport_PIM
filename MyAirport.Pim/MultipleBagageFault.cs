using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyAirport.Pim.Entities
{
    [DataContract]
    sealed public class MultipleBagageFault
    {
        [DataMember]
        public List<BagageDefinition> ListBagages { get; set; }
        [DataMember]
        public string CodeIata { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
