using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaKneeSkinnedMeshRendererServiceCommand {
        void SetBlendShapeWeight(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID, float weight);
    }
}

