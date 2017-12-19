using System.Configuration;

namespace MyAirport.Pim.Models
{
    /// <summary>
    /// Factory to create an uniq instance of AbstractDefinition
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Singleton of AbstractDefinition
        /// </summary>
        private static AbstractDefinition singleton = null;

        /// <summary>
        /// Factory of AbstractDefinition
        /// </summary>
        public static AbstractDefinition Model
        {
            get
            {
                if (singleton == null)
                {
                    switch (ConfigurationManager.AppSettings["Factory"])
                    {
                        case "Sql":
                            singleton = new Sql();
                            break;
                        case "Natif":
                            singleton = new Natif();
                            break;
                        default:
                            singleton = new Natif();
                            break;
                    }
                }
                return singleton;
            }
        }
    }
}

