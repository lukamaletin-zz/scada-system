using System;
using System.ServiceModel;
using SCADACommon;
using SCADACommon.Service;

namespace AlarmDisplay
{
    public class AlarmDisplay : IAlarmCallback
    {
        public static void Main(string[] args)
        {
            var address = new Uri(ScadaConstants.AlarmUri);
            var binding = new NetTcpBinding {Security = {Mode = SecurityMode.None}};
            var factory = new DuplexChannelFactory<IAlarm>(new AlarmDisplay(), binding, new EndpointAddress(address));
            var proxy = factory.CreateChannel();

            proxy.SubscribeToAlarms();
            Console.ReadLine();
            try
            {
                proxy.UnsubscribeFromAlarms();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void LogAlarmToConsole(string alarmMessage)
        {
            Console.WriteLine(alarmMessage);
        }
    }
}