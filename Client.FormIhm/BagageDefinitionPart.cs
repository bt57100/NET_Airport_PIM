using System;

namespace Client.FormIhm.ServiceReferencePim
{
    /// <summary>
    /// Partial class of the bagageDefinition class received from the service
    /// This partial class is only used for display issue on client side
    /// </summary>
    partial class BagageDefinition
    {
        /// <summary>
        /// Convert the BagageDefinition to a displayable String 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return IdBagage + " " + CodeIata + " " + Compagnie + " " + Ligne + " " + DateVol + "     " + Itineraire + "      " + Prioritaire + "           " + EnContinuation + "           " + Rush;
        }
    }
}
