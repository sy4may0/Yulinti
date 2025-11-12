using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaHipsSkinnedMeshRendererServiceCommand {
        void SetBlendShapeWeight(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID, float weight);
    }
}