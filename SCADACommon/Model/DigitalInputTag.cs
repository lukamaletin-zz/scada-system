using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class DigitalInputTag : InputTag
    {
        public DigitalInputTag()
        {
        }

        public DigitalInputTag(int scanTime, List<Alarm> alarms, bool onScan, bool autoMode, FunctionType functionType)
            : base(scanTime, alarms, onScan, autoMode, functionType)
        {
        }

        public DigitalInputTag(string id, string description, SimulationDriver driver, string address, int scanTime,
            List<Alarm> alarms, bool onScan, bool autoMode, FunctionType functionType)
            : base(id, description, driver, address, scanTime, alarms, onScan, autoMode, functionType)
        {
        }
    }
}