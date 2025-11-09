using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.SMR.Internal;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaKneeSkinnedMeshRendererService {
        private readonly SkinnedMeshRenderer _kneeMesh;
        private readonly FukaKneeCorrectiveShapeMap _kneeCorrectiveShapeMap;

        public FukaKneeSkinnedMeshRendererService(
            IFukaKneeCorrectiveShapeConfig kneeCorrectiveShapeConfig
        ) {
            if (kneeCorrectiveShapeConfig.Mesh == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaKneeSkinnedMeshRendererService)のKneeCorrectiveShapeConfigのMeshがnullです。");
            }
            _kneeMesh = kneeCorrectiveShapeConfig.Mesh;
            _kneeCorrectiveShapeMap = new FukaKneeCorrectiveShapeMap(kneeCorrectiveShapeConfig);
        }

        public void SetBlendShapeWeight(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID, float weight) {
            int index = _kneeCorrectiveShapeMap.Get(kneeCorrectiveShapeID);
            _kneeMesh.SetBlendShapeWeight(index, weight);
        }

        public float GetBlendShapeWeight(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) {
            int index = _kneeCorrectiveShapeMap.Get(kneeCorrectiveShapeID);
            return _kneeMesh.GetBlendShapeWeight(index);
        }
    }
}
