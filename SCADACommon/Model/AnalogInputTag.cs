using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class AnalogInputTag : InputTag
    {
        [DataMember] private double _lowLimit;

        [DataMember] private double _highLimit;

        [DataMember] private string _units;

        public AnalogInputTag()
        {
        }

        public AnalogInputTag(double lowLimit, double highLimit, string units)
        {
            _lowLimit = lowLimit;
            _highLimit = highLimit;
            _units = units;
        }

        public AnalogInputTag(int scanTime, List<Alarm> alarms, bool onScan, bool autoMode, FunctionType functionType,
            double lowLimit, double highLimit, string units) : base(scanTime, alarms, onScan, autoMode, functionType)
        {
            _lowLimit = lowLimit;
            _highLimit = highLimit;
            _units = units;
        }

        public AnalogInputTag(string id, string description, SimulationDriver driver, string address, int scanTime,
            List<Alarm> alarms, bool onScan, bool autoMode, FunctionType functionType, double lowLimit, double highLimit,
            string units) : base(id, description, driver, address, scanTime, alarms, onScan, autoMode, functionType)
        {
            _lowLimit = lowLimit;
            _highLimit = highLimit;
            _units = units;
        }

        public double LowLimit
        {
            get { return _lowLimit; }
            set { _lowLimit = value; }
        }

        public double HighLimit
        {
            get { return _highLimit; }
            set { _highLimit = value; }
        }

        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }
    }
}