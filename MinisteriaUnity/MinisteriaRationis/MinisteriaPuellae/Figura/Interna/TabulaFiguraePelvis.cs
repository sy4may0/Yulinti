using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna {
    public sealed class TabulaFiguraePelvis {
        private readonly int[] _figuraeIndexes;

        public TabulaFiguraePelvis(IFukaHipsCorrectiveShapeConfig hipsCorrectiveShapeConfig) {
            _figuraeIndexes = new int[(int)IDPuellaeFiguraePelvis.Count];
            SkinnedMeshRenderer mesh = hipsCorrectiveShapeConfig.Mesh;
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipX90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftX90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftX150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipY90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftY90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipX90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightX90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightX150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipY90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightY90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csAnusX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.X150AnusBlendShapeName);

            for (int i = 0; i < (int)IDPuellaeFiguraePelvis.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"IDPuellaeFiguraePelvis {(IDPuellaeFiguraePelvis)i} が見つかりません。IConfiguratioPuellaeFiguraePelvisのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Lego(IDPuellaeFiguraePelvis idFiguraePelvis) => _figuraeIndexes[(int)idFiguraePelvis];
    }
}