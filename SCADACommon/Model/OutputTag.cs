using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class OutputTag : Tag
    {
        [DataMember] private double _initialValue;

        public OutputTag()
        {
        }

        public OutputTag(double initialValue)
        {
            _initialValue = initialValue;
        }

        public OutputTag(string id, string description, SimulationDriver driver, string address, double initialValue)
            : base(id, description, driver, address)
        {
            _initialValue = initialValue;
            SetValue(_initialValue);
        }

        public double InitialValue
        {
            get { return _initialValue; }
            set
            {
                _initialValue = value;
                SetValue(_initialValue);
            }
        }
    }
}