using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaHipsSkinnedMeshRendererRO : IFukaHipsSkinnedMeshRendererServiceQuery {
        private readonly FukaHipsSkinnedMeshRendererService _fukaHipsSkinnedMeshRendererService;
        public FukaHipsSkinnedMeshRendererRO(FukaHipsSkinnedMeshRendererService fukaHipsSkinnedMeshRendererService) {
            if (fukaHipsSkinnedMeshRendererService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaHipsSkinnedMeshRendererRO)のFukaHipsSkinnedMeshRendererServiceがnullです。");
            }
            _fukaHipsSkinnedMeshRendererService = fukaHipsSkinnedMeshRendererService;
        }
        public float GetBlendShapeWeight(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) {
            return _fukaHipsSkinnedMeshRendererService.GetBlendShapeWeight(hipsCorrectiveShapeID);
        }
    }
}