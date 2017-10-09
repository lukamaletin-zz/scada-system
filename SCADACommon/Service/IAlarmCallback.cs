using System.ServiceModel;

namespace SCADACommon.Service
{
    [ServiceContract]
    public interface IAlarmCallback
    {
        [OperationContract(IsOneWay = true)]
        void LogAlarmToConsole(string alarmMessage);
    }
}