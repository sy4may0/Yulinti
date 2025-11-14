using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna {
    public sealed class TabulaFiguraePelvis {
        private readonly int[] _figuraeIndexes;

        public TabulaFiguraePelvis(IFukaHipsCorrectiveShapeConfig hipsCorrectiveShapeConfig) {
            _figuraeIndexes = new int[(int)FukaHipsCorrectiveShapeID.Count];
            SkinnedMeshRenderer mesh = hipsCorrectiveShapeConfig.Mesh;
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csLHipX90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftX90BlendShapeName);
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csLHipX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftX150BlendShapeName);
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csLHipY90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftY90BlendShapeName);
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csRHipX90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightX90BlendShapeName);
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csRHipX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightX150BlendShapeName);
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csRHipY90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightY90BlendShapeName);
            _figuraeIndexes[(int)FukaHipsCorrectiveShapeID.csAnusX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.X150AnusBlendShapeName);

            for (int i = 0; i < (int)FukaHipsCorrectiveShapeID.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    ModeratorErrorum.Fatal($"FukaHipsCorrectiveShapeID {(FukaHipsCorrectiveShapeID)i} が見つかりません。IFukaHipsCorrectiveShapeConfigのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Lego(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) => _figuraeIndexes[(int)hipsCorrectiveShapeID];
    }
}