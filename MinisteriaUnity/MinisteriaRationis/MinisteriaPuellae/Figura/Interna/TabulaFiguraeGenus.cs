using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna {
    public sealed class TabulaFiguraeGenus {
        private readonly int[] _figuraeIndexes;

        public TabulaFiguraeGenus(IFukaKneeCorrectiveShapeConfig kneeCorrectiveShapeConfig) {
            _figuraeIndexes = new int[(int)IDPuellaeFiguraeGenus.Count];
            SkinnedMeshRenderer mesh = kneeCorrectiveShapeConfig.Mesh;
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee90] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee150] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee120Offset] = mesh.sharedMesh.GetBlendShapeIndex(kneeCorrectiveShapeConfig.X120OffsetBlendShapeName);

            for (int i = 0; i < (int)IDPuellaeFiguraeGenus.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"IDPuellaeFiguraeGenus {(IDPuellaeFiguraeGenus)i} が見つかりません。IConfiguratioPuellaeFiguraeGenusのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Lego(IDPuellaeFiguraeGenus idFiguraeGenus) => _figuraeIndexes[(int)idFiguraeGenus];
    }
}