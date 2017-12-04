using System;

namespace Client.FormIhm.ServiceReferencePim
{
    partial class BagageDefinition
    {
        public override String ToString()
        {
            return IdBagage + "\t" + CodeIata + "\t" + Compagnie;
        }
    }
}
