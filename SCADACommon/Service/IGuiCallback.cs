using System.ServiceModel;
using SCADACommon.Model;

namespace SCADACommon.Service
{
    [ServiceContract]
    public interface IGuiCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnAddTag(Tag tag);

        [OperationContract(IsOneWay = true)]
        void OnRemoveTag(Tag tag);

        [OperationContract(IsOneWay = true)]
        void OnUpdateTag(Tag tag);
    }
}