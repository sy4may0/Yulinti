using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaKneeSkinnedMeshRendererRW : IFukaKneeSkinnedMeshRendererServiceCommand, IFukaKneeSkinnedMeshRendererServiceQuery {
        private readonly FukaKneeSkinnedMeshRendererService _fukaKneeSkinnedMeshRendererService;

        public FukaKneeSkinnedMeshRendererRW(FukaKneeSkinnedMeshRendererService fukaKneeSkinnedMeshRendererService) {
            if (fukaKneeSkinnedMeshRendererService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaKneeSkinnedMeshRendererRW)のFukaKneeSkinnedMeshRendererServiceがnullです。");
            }
            _fukaKneeSkinnedMeshRendererService = fukaKneeSkinnedMeshRendererService;
        }

        public float GetBlendShapeWeight(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) {
            return _fukaKneeSkinnedMeshRendererService.GetBlendShapeWeight(kneeCorrectiveShapeID);
        }
        public void SetBlendShapeWeight(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID, float weight) {
            _fukaKneeSkinnedMeshRendererService.SetBlendShapeWeight(kneeCorrectiveShapeID, weight);
        }
    }
}

