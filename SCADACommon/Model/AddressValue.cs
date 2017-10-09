using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class AddressValue
    {
        [DataMember] private string _address;

        [DataMember] private double _value;

        public AddressValue()
        {
        }

        public AddressValue(string address, double value)
        {
            _address = address;
            _value = value;
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}