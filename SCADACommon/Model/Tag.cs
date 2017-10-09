using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    [XmlInclude(typeof(AnalogInputTag))]
    [XmlInclude(typeof(AnalogOutputTag))]
    [XmlInclude(typeof(DigitalInputTag))]
    [XmlInclude(typeof(DigitalOutputTag))]
    [KnownType(typeof(AnalogInputTag))]
    [KnownType(typeof(AnalogOutputTag))]
    [KnownType(typeof(DigitalInputTag))]
    [KnownType(typeof(DigitalOutputTag))]
    public class Tag
    {
        [DataMember] private string _id;

        [DataMember] private string _description;

        [DataMember] private SimulationDriver _driver;

        [DataMember] private string _address;

        public Tag()
        {
        }

        public Tag(string id, string description, SimulationDriver driver, string address)
        {
            _id = id;
            _description = description;
            _driver = driver;
            _address = address;
            Driver?.AddressValues.Add(new AddressValue(Address, 0));
        }

        public double GetValue()
        {
            return Driver?.AddressValues.First(av => av.Address == Address).Value ?? 0;
        }

        public void SetValue(double value)
        {
            if (Driver != null)
            {
                Driver.AddressValues.First(av => av.Address == Address).Value = value;
            }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public SimulationDriver Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                var addressValue = Driver.AddressValues.FirstOrDefault(av => av.Address == Address);
                if (addressValue == null)
                {
                    _driver.AddressValues.Add(new AddressValue(Address, 0));
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}