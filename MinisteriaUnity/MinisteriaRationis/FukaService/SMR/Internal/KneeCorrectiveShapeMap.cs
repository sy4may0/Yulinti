using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices.FukaService.SMR.Internal {
    public sealed class FukaKneeCorrectiveShapeMap {
        private readonly int[] _kneeCorrectiveShapeIndexes;

        public FukaKneeCorrectiveShapeMap(IFukaKneeCorrectiveShapeConfig kneeCorrectiveShapeConfig) {
            _kneeCorrectiveShapeIndexes = new int[(int)FukaKneeCorrectiveShapeID.Count];
            SkinnedMeshRenderer mesh = kneeCorrectiveShapeConfig.Mesh;
            _kneeCorrectiveShapeIndexes[(int)FukaKneeCorrectiveShapeID.csknee90] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X90BlendShapeName);
            _kneeCorrectiveShapeIndexes[(int)FukaKneeCorrectiveShapeID.csknee150] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X150BlendShapeName);
            _kneeCorrectiveShapeIndexes[(int)FukaKneeCorrectiveShapeID.csknee120Offset] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X120OffsetBlendShapeName);

            for (int i = 0; i < (int)FukaKneeCorrectiveShapeID.Count; i++) {
                if (_kneeCorrectiveShapeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"FukaKneeCorrectiveShapeID {(FukaKneeCorrectiveShapeID)i} が見つかりません。IFukaKneeCorrectiveShapeConfigのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Get(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) => _kneeCorrectiveShapeIndexes[(int)kneeCorrectiveShapeID];
    }
}