using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna {
    public sealed class TabulaFiguraeGenus {
        private readonly int[] _figuraeIndexes;

        public TablaFiguraeGenus(IFukaKneeCorrectiveShapeConfig kneeCorrectiveShapeConfig) {
            _figurae = new int[(int)FukaKneeCorrectiveShapeID.Count];
            SkinnedMeshRenderer mesh = kneeCorrectiveShapeConfig.Mesh;
            _figuraeIndexes[(int)FukaKneeCorrectiveShapeID.csknee90] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X90BlendShapeName);
            _figuraeIndexes[(int)FukaKneeCorrectiveShapeID.csknee150] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X150BlendShapeName);
            _figuraeIndexes[(int)FukaKneeCorrectiveShapeID.csknee120Offset] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X120OffsetBlendShapeName);

            for (int i = 0; i < (int)FukaKneeCorrectiveShapeID.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"FukaKneeCorrectiveShapeID {(FukaKneeCorrectiveShapeID)i} が見つかりません。IFukaKneeCorrectiveShapeConfigのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Lego(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) => _figuraeIndexes[(int)kneeCorrectiveShapeID];
    }
}