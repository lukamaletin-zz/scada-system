using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class Alarm
    {
        [DataMember] private string _id;

        [DataMember] private double _lowLimit;

        [DataMember] private double _highLimit;

        public Alarm()
        {
        }

        public Alarm(string id, double lowLimit, double highLimit)
        {
            _id = id;
            _lowLimit = lowLimit;
            _highLimit = highLimit;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
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
    }
}