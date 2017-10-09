using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class DigitalOutputTag : OutputTag
    {
        public DigitalOutputTag()
        {
        }

        public DigitalOutputTag(double initialValue) : base(initialValue)
        {
        }

        public DigitalOutputTag(string id, string description, SimulationDriver driver, string address,
            double initialValue) : base(id, description, driver, address, initialValue)
        {
        }
    }
}