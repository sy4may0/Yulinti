using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.SMR.Internal;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaHipsSkinnedMeshRendererService {
        private readonly SkinnedMeshRenderer _hipsMesh;
        private readonly FukaHipsCorrectiveShapeMap _hipsCorrectiveShapeMap;

        public FukaHipsSkinnedMeshRendererService(
            IFukaHipsCorrectiveShapeConfig hipsCorrectiveShapeConfig
        ) {
            if (hipsCorrectiveShapeConfig.Mesh == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaHipsSkinnedMeshRendererService)のHipsCorrectiveShapeConfigのMeshがnullです。");
            }
            _hipsMesh = hipsCorrectiveShapeConfig.Mesh;
            _hipsCorrectiveShapeMap = new FukaHipsCorrectiveShapeMap(hipsCorrectiveShapeConfig);
        }

        public float GetBlendShapeWeight(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) {
            int index = _hipsCorrectiveShapeMap.Get(hipsCorrectiveShapeID);
            return _hipsMesh.GetBlendShapeWeight(index);
        }

        public void SetBlendShapeWeight(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID, float weight) {
            int index = _hipsCorrectiveShapeMap.Get(hipsCorrectiveShapeID);
            _hipsMesh.SetBlendShapeWeight(index, weight);
        }
    }
}