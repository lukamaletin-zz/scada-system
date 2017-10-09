using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public class InputTag : Tag
    {
        [DataMember] private int _scanTime;

        [DataMember] private List<Alarm> _alarms;

        [DataMember] private bool _onScan;

        [DataMember] private bool _autoMode;

        [DataMember] private FunctionType _functionType;

        public InputTag()
        {
        }

        public InputTag(int scanTime, List<Alarm> alarms, bool onScan, bool autoMode, FunctionType functionType)
        {
            _scanTime = scanTime;
            _alarms = alarms;
            _onScan = onScan;
            _autoMode = autoMode;
            _functionType = functionType;
        }

        public InputTag(string id, string description, SimulationDriver driver, string address, int scanTime,
            List<Alarm> alarms, bool onScan, bool autoMode, FunctionType functionType)
            : base(id, description, driver, address)
        {
            _scanTime = scanTime;
            _alarms = alarms;
            _onScan = onScan;
            _autoMode = autoMode;
            _functionType = functionType;
        }

        public int ScanTime
        {
            get { return _scanTime; }
            set { _scanTime = value; }
        }

        public List<Alarm> Alarms
        {
            get { return _alarms; }
            set { _alarms = value; }
        }

        public bool OnScan
        {
            get { return _onScan; }
            set { _onScan = value; }
        }

        public bool AutoMode
        {
            get { return _autoMode; }
            set { _autoMode = value; }
        }

        public FunctionType FunctionType
        {
            get { return _functionType; }
            set { _functionType = value; }
        }
    }
}