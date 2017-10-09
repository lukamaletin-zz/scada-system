using System.ServiceModel;
using SCADACommon.Model;

namespace SCADACommon.Service
{
    [ServiceContract(CallbackContract = typeof(IGuiCallback))]
    public interface IDatabaseManager
    {
        [OperationContract(IsOneWay = true)]
        void SubscribeToTags();

        [OperationContract(IsOneWay = true)]
        void UnsubscribeFromTags();

        [OperationContract]
        bool AddTag(Tag tag);

        [OperationContract]
        bool RemoveTag(string tagId);

        [OperationContract]
        bool UpdateTag(Tag updatedTag);

        [OperationContract]
        bool AddInputTagAlarm(string tagId, Alarm alarm);

        [OperationContract]
        bool RemoveInputTagAlarm(string tagId, string alarmId);

        [OperationContract(IsOneWay = true)]
        void PublishTagAdded(Tag tag);

        [OperationContract(IsOneWay = true)]
        void PublishTagRemoved(Tag tag);

        [OperationContract(IsOneWay = true)]
        void PublishTagUpdated(Tag tag);
    }
}