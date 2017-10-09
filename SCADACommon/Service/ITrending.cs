using System.ServiceModel;
using SCADACommon.Model;

namespace SCADACommon.Service
{
    [ServiceContract(CallbackContract = typeof(IGuiCallback))]
    public interface ITrending
    {
        [OperationContract(IsOneWay = true)]
        void SubscribeToTags();

        [OperationContract(IsOneWay = true)]
        void UnsubscribeFromTags();

        [OperationContract(IsOneWay = true)]
        void PublishTagAdded(Tag tag);

        [OperationContract(IsOneWay = true)]
        void PublishTagRemoved(Tag tag);

        [OperationContract(IsOneWay = true)]
        void PublishTagUpdated(Tag tag);
    }
}