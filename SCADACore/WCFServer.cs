using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Xml.Serialization;
using SCADACommon;
using SCADACommon.Model;
using SCADACommon.Service;

namespace SCADACore
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfServer : IDatabaseManager, IAlarm, ITrending
    {
        private delegate void AlarmHandler(string alarmMessage);

        private static Dictionary<string, Tag> _tags;
        private static Dictionary<string, Thread> _threads;
        private static readonly object Locker = new object();
        private static readonly object FileLocker = new object();
        private static readonly object CallbacksLocker = new object();
        private static event AlarmHandler AlarmTriggered;
        private static IAlarmCallback _alarmDisplayCallback;
        private static List<IGuiCallback> _guiCallbacks;
        private static SimulationDriver _simulationDriver;

        public WcfServer()
        {
            _tags = new Dictionary<string, Tag>();
            _threads = new Dictionary<string, Thread>();
            _guiCallbacks = new List<IGuiCallback>();
            AlarmTriggered += LogAlarmToFile;
            AlarmTriggered += PublishAlarm;
            DeserializeTags();
        }

        public static void Main(string[] args)
        {
            var address1 = new Uri(ScadaConstants.DatabaseManagerUri);
            var address2 = new Uri(ScadaConstants.AlarmUri);
            var address3 = new Uri(ScadaConstants.TrendingUri);

            var binding1 = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var binding2 = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var binding3 = new NetTcpBinding {Security = {Mode = SecurityMode.None}};

            var service = new ServiceHost(typeof(WcfServer));

            service.AddServiceEndpoint(typeof(IDatabaseManager), binding1, address1);
            service.AddServiceEndpoint(typeof(IAlarm), binding2, address2);
            service.AddServiceEndpoint(typeof(ITrending), binding3, address3);

            service.Open();
            Console.WriteLine("WCFServer running...");
            Console.ReadLine();
            SerialzieTags();
            AbortThreads();
            service.Close();
        }

        private static void OnAlarmTriggered(string alarmMessage)
        {
            AlarmTriggered?.Invoke(alarmMessage);
        }

        private static void LogAlarmToFile(string alarmMessage)
        {
            lock (FileLocker)
            {
                using (var writer = File.AppendText(ScadaConstants.AlarmsLogPath))
                {
                    writer.WriteLine(alarmMessage);
                }
            }
        }

        private static void SerialzieTags()
        {
            using (var writer = new StreamWriter(ScadaConstants.ConfigPath))
            {
                var serializer = new XmlSerializer(typeof(List<Tag>));
                serializer.Serialize(writer, _tags.Values.ToList());
            }
        }

        private void DeserializeTags()
        {
            if (!File.Exists("scadaConfig.xml"))
            {
                _simulationDriver = new SimulationDriver();
                return;
            }
            using (var reader = new StreamReader("scadaConfig.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Tag>));
                var tagsList = (List<Tag>) serializer.Deserialize(reader);

                if (tagsList == null || tagsList.Count == 0)
                {
                    _simulationDriver = new SimulationDriver();
                }
                else
                {
                    _simulationDriver = tagsList[0].Driver;
                }

                lock (Locker)
                {
                    if (tagsList != null)
                    {
                        _tags = tagsList.ToDictionary(tag => tag.Id);
                    }
                    foreach (var tag in _tags.Values)
                    {
                        if (tag is InputTag && ((InputTag) tag).AutoMode)
                        {
                            StartInputTagUpdatingThread(tag);
                        }
                    }
                }
            }
        }

        private static void AbortThreads()
        {
            foreach (var thread in _threads.Values)
            {
                thread.Abort();
            }
        }

        private void StartInputTagUpdatingThread(Tag tag)
        {
            var thread = new Thread(PeriodicallyUpdateInputTag);
            _threads.Add(tag.Id, thread);
            thread.Start(tag);
        }

        private static void StopInputTagUpdatingThread(string tagId)
        {
            if (_threads.ContainsKey(tagId))
            {
                var thread = _threads[tagId];
                _threads.Remove(tagId);
                thread.Abort();
            }
        }

        private void PeriodicallyUpdateInputTag(object obj)
        {
            var tag = (Tag) obj;
            while (true)
            {
                lock (Locker)
                {
                    tag = _tags[tag.Id];
                }

                if (!(tag is InputTag))
                {
                    continue;
                }

                if (((InputTag) tag).AutoMode)
                {
                    UpdateInputTagValue((InputTag) tag);
                    CheckInputTagAlarms((InputTag) tag);
                }
                Thread.Sleep(((InputTag) tag).ScanTime);
            }
        }

        private void UpdateInputTagValue(InputTag tag)
        {
            switch (tag.FunctionType)
            {
                case FunctionType.Sine:
                    tag.SetValue(SimulationDriver.Sine());
                    break;
                case FunctionType.Cosine:
                    tag.SetValue(SimulationDriver.Cosine());
                    break;
                case FunctionType.Ramp:
                    tag.SetValue(SimulationDriver.Ramp());
                    break;
                case FunctionType.Triangle:
                    tag.SetValue(SimulationDriver.Triangle());
                    break;
                case FunctionType.Rectangle:
                    tag.SetValue(SimulationDriver.Rectangle());
                    break;
                case FunctionType.Digital:
                    tag.SetValue(SimulationDriver.Digital());
                    break;
            }
            PublishTagUpdated(tag);
        }

        private static void CheckInputTagAlarms(InputTag tag)
        {
            foreach (var alarm in tag.Alarms)
            {
                var value = tag.GetValue();
                if (value <= alarm.LowLimit)
                {
                    OnAlarmTriggered(
                        $"{DateTime.Now}: {tag.Id} value {value:0.###} is lower than {alarm.Id} low limit of {alarm.LowLimit}!");
                }
                else if (value >= alarm.HighLimit)
                {
                    OnAlarmTriggered(
                        $"{DateTime.Now}: {tag.Id} value {value:0.###} is higher than {alarm.Id} high limit of {alarm.HighLimit}!");
                }
            }
        }

        public bool AddTag(Tag tag)
        {
            lock (Locker)
            {
                if (_tags.ContainsKey(tag.Id) || _tags.Values.Any(otherTag => otherTag.Address == tag.Address))
                {
                    return false;
                }

                tag.Driver = _simulationDriver;
                if (tag is OutputTag)
                {
                    tag.SetValue(((OutputTag) tag).InitialValue);
                }

                _tags[tag.Id] = tag;
                PublishTagAdded(tag);
                if (tag is InputTag && ((InputTag) tag).AutoMode)
                {
                    StartInputTagUpdatingThread(tag);
                }
                return true;
            }
        }

        public bool RemoveTag(string tagId)
        {
            lock (Locker)
            {
                if (!_tags.ContainsKey(tagId))
                {
                    return false;
                }

                var tag = _tags[tagId];
                _tags.Remove(tagId);
                PublishTagRemoved(tag);

                StopInputTagUpdatingThread(tagId);
                return true;
            }
        }

        public bool AddInputTagAlarm(string tagId, Alarm alarm)
        {
            lock (Locker)
            {
                if (!_tags.ContainsKey(tagId) || !(_tags[tagId] is InputTag))
                {
                    return false;
                }

                var tag = _tags[tagId];
                var inputTag = (InputTag) tag;
                var otherAlarm = inputTag.Alarms.FirstOrDefault(a => a.Id == alarm.Id);
                if (otherAlarm != null)
                {
                    return false;
                }
                inputTag.Alarms.Add(alarm);
                PublishTagUpdated(tag);
                return true;
            }
        }

        public bool RemoveInputTagAlarm(string tagId, string alarmId)
        {
            lock (Locker)
            {
                if (!_tags.ContainsKey(tagId) || !(_tags[tagId] is InputTag))
                {
                    return false;
                }

                var tag = _tags[tagId];
                var inputTag = (InputTag) tag;
                var alarm = inputTag.Alarms.FirstOrDefault(a => a.Id == alarmId);
                if (alarm == null)
                {
                    return false;
                }
                inputTag.Alarms.Remove(alarm);
                PublishTagUpdated(tag);
                return true;
            }
        }

        public bool UpdateTag(Tag updatedTag)
        {
            var originalTag = _tags.Values.FirstOrDefault(t => t.Id == updatedTag.Id);
            if (originalTag == null)
            {
                return false;
            }

            if (updatedTag is OutputTag)
            {
                var value = updatedTag.GetValue();
                updatedTag.Driver = originalTag.Driver;
                updatedTag.SetValue(value);
            }
            else
            {
                updatedTag.Driver = originalTag.Driver;
            }


            if (updatedTag is InputTag)
            {
                ((InputTag) updatedTag).Alarms = ((InputTag) originalTag).Alarms;
            }

            lock (Locker)
            {
                _tags[originalTag.Id] = updatedTag;
            }

            if (updatedTag is InputTag)
            {
                CheckInputTagAlarms((InputTag) updatedTag);

                if (((InputTag) updatedTag).AutoMode && !((InputTag) originalTag).AutoMode)
                {
                    StartInputTagUpdatingThread(updatedTag);
                }
                else if (!((InputTag) updatedTag).AutoMode && ((InputTag) originalTag).AutoMode)
                {
                    StopInputTagUpdatingThread(updatedTag.Id);
                }
            }

            PublishTagUpdated(updatedTag);
            return true;
        }

        public void SubscribeToAlarms()
        {
            _alarmDisplayCallback = OperationContext.Current.GetCallbackChannel<IAlarmCallback>();
        }

        public void UnsubscribeFromAlarms()
        {
            _alarmDisplayCallback = null;
        }

        public void PublishAlarm(string alarmMessage)
        {
            _alarmDisplayCallback?.LogAlarmToConsole(alarmMessage);
        }

        public void SubscribeToTags()
        {
            lock (CallbacksLocker)
            {
                _guiCallbacks.Add(OperationContext.Current.GetCallbackChannel<IGuiCallback>());

                foreach (var tag in _tags.Values)
                {
                    PublishTagAdded(tag);
                }
            }
        }

        public void UnsubscribeFromTags()
        {
            try
            {
                lock (CallbacksLocker)
                {
                    _guiCallbacks.Remove(OperationContext.Current.GetCallbackChannel<IGuiCallback>());
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void PublishTagAdded(Tag tag)
        {
            lock (CallbacksLocker)
            {
                foreach (var guiCallback in _guiCallbacks)
                {
                    guiCallback?.OnAddTag(tag);
                }
            }
        }

        public void PublishTagRemoved(Tag tag)
        {
            lock (CallbacksLocker)
            {
                foreach (var guiCallback in _guiCallbacks)
                {
                    guiCallback?.OnRemoveTag(tag);
                }
            }
        }

        public void PublishTagUpdated(Tag tag)
        {
            lock (CallbacksLocker)
            {
                foreach (var guiCallback in _guiCallbacks)
                {
                    guiCallback?.OnUpdateTag(tag);
                }
            }
        }
    }
}