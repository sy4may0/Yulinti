using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeFiguraeGenus {
        private readonly int[] _figuraeIndexes;

        public TabulaPuellaeFiguraeGenus(IConfiguratioPuellaeFiguraeGenus config) {
            _figuraeIndexes = new int[(int)IDPuellaeFiguraeGenus.Count];
            SkinnedMeshRenderer mesh = config.Mesh;
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee90] = mesh.sharedMesh.GetBlendShapeIndex(config.X90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee150] = mesh.sharedMesh.GetBlendShapeIndex(config.X150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee120Offset] = mesh.sharedMesh.GetBlendShapeIndex(config.X120OffsetBlendShapeName);

            for (int i = 0; i < (int)IDPuellaeFiguraeGenus.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"IDPuellaeFiguraeGenus {(IDPuellaeFiguraeGenus)i} が見つかりません。IConfiguratioPuellaeFiguraeGenusのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Lego(IDPuellaeFiguraeGenus idFiguraeGenus) => _figuraeIndexes[(int)idFiguraeGenus];
    }
}
