using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyAirport.Pim.Entities
{
    [DataContract]
    sealed public class MultipleBagageFault
    {
        /// <summary>
        /// List of bagages
        /// </summary>
        [DataMember]
        public List<BagageDefinition> ListBagages { get; set; }
        /// <summary>
        /// Corresponding CODE_IATA
        /// </summary>
        [DataMember]
        public string CodeIata { get; set; }
        /// <summary>
        /// Fault message
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
