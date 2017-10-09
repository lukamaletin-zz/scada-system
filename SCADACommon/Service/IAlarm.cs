using System.ServiceModel;

namespace SCADACommon.Service
{
    [ServiceContract(CallbackContract = typeof(IAlarmCallback))]
    public interface IAlarm
    {
        [OperationContract(IsOneWay = true)]
        void SubscribeToAlarms();

        [OperationContract(IsOneWay = true)]
        void UnsubscribeFromAlarms();

        [OperationContract(IsOneWay = true)]
        void PublishAlarm(string alarmMessage);
    }
}