using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna {
    public sealed class TabulaFiguraePelvis {
        private readonly int[] _figuraeIndexes;

        public TabulaFiguraePelvis(IConfiguratioPuellaeFiguraePelvis config) {
            _figuraeIndexes = new int[(int)IDPuellaeFiguraePelvis.Count];
            SkinnedMeshRenderer mesh = config.Mesh;
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipX90] = mesh.sharedMesh.GetBlendShapeIndex(config.LeftX90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipX150] = mesh.sharedMesh.GetBlendShapeIndex(config.LeftX150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipY90] = mesh.sharedMesh.GetBlendShapeIndex(config.LeftY90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipX90] = mesh.sharedMesh.GetBlendShapeIndex(config.RightX90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipX150] = mesh.sharedMesh.GetBlendShapeIndex(config.RightX150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipY90] = mesh.sharedMesh.GetBlendShapeIndex(config.RightY90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csAnusX150] = mesh.sharedMesh.GetBlendShapeIndex(config.X150AnusBlendShapeName);

            for (int i = 0; i < (int)IDPuellaeFiguraePelvis.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"IDPuellaeFiguraePelvis {(IDPuellaeFiguraePelvis)i} が見つかりません。IConfiguratioPuellaeFiguraePelvisのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Lego(IDPuellaeFiguraePelvis idFiguraePelvis) => _figuraeIndexes[(int)idFiguraePelvis];
    }
}