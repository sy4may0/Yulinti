using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaHipsSkinnedMeshRendererRW : IFukaHipsSkinnedMeshRendererServiceCommand, IFukaHipsSkinnedMeshRendererServiceQuery {
        private readonly FukaHipsSkinnedMeshRendererService _fukaHipsSkinnedMeshRendererService;

        public FukaHipsSkinnedMeshRendererRW(FukaHipsSkinnedMeshRendererService fukaHipsSkinnedMeshRendererService) {
            if (fukaHipsSkinnedMeshRendererService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaHipsSkinnedMeshRendererRW)のFukaHipsSkinnedMeshRendererServiceがnullです。");
            }
            _fukaHipsSkinnedMeshRendererService = fukaHipsSkinnedMeshRendererService;
        }

        public float GetBlendShapeWeight(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) {
            return _fukaHipsSkinnedMeshRendererService.GetBlendShapeWeight(hipsCorrectiveShapeID);
        }
        public void SetBlendShapeWeight(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID, float weight) {
            _fukaHipsSkinnedMeshRendererService.SetBlendShapeWeight(hipsCorrectiveShapeID, weight);
        }
    }
}