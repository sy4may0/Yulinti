using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaKneeSkinnedMeshRendererRO : IFukaKneeSkinnedMeshRendererServiceQuery {
        private readonly FukaKneeSkinnedMeshRendererService _fukaKneeSkinnedMeshRendererService;
        public FukaKneeSkinnedMeshRendererRO(FukaKneeSkinnedMeshRendererService fukaKneeSkinnedMeshRendererService) {
            if (fukaKneeSkinnedMeshRendererService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaKneeSkinnedMeshRendererRO)のFukaKneeSkinnedMeshRendererServiceがnullです。");
            }
            _fukaKneeSkinnedMeshRendererService = fukaKneeSkinnedMeshRendererService;
        }
        public float GetBlendShapeWeight(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) {
            return _fukaKneeSkinnedMeshRendererService.GetBlendShapeWeight(kneeCorrectiveShapeID);
        }
    }
}

