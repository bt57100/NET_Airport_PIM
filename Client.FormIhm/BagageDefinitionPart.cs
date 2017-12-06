using System;

namespace Client.FormIhm.ServiceReferencePim
{
    partial class BagageDefinition
    {
        public override String ToString()
        {
            return IdBagage + " " + CodeIata + " " + Compagnie + " " + Ligne + " " + DateVol + "     " + Itineraire + "      " + Prioritaire + "           " + EnContinuation + "           " + Rush;
        }
    }
}
