using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class AnalogOutputTag : OutputTag
    {
        [DataMember] private double _lowLimit;

        [DataMember] private double _highLimit;

        [DataMember] private string _units;

        public AnalogOutputTag()
        {
        }

        public AnalogOutputTag(double lowLimit, double highLimit, string units)
        {
            _lowLimit = lowLimit;
            _highLimit = highLimit;
            _units = units;
        }

        public AnalogOutputTag(double initialValue, double lowLimit, double highLimit, string units)
            : base(initialValue)
        {
            _lowLimit = lowLimit;
            _highLimit = highLimit;
            _units = units;
        }

        public AnalogOutputTag(string id, string description, SimulationDriver driver, string address,
            double initialValue, double lowLimit, double highLimit, string units)
            : base(id, description, driver, address, initialValue)
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