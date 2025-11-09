using UnityEngine;
using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices.FukaService.SMR.Internal {
    public sealed class FukaHipsCorrectiveShapeMap {
        private readonly int[] _hipsCorrectiveShapeIndexes;

        public FukaHipsCorrectiveShapeMap(IFukaHipsCorrectiveShapeConfig hipsCorrectiveShapeConfig) {
            _hipsCorrectiveShapeIndexes = new int[(int)FukaHipsCorrectiveShapeID.Count];
            SkinnedMeshRenderer mesh = hipsCorrectiveShapeConfig.Mesh;
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csLHipX90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftX90BlendShapeName);
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csLHipX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftX150BlendShapeName);
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csLHipY90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.LeftY90BlendShapeName);
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csRHipX90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightX90BlendShapeName);
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csRHipX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightX150BlendShapeName);
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csRHipY90] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.RightY90BlendShapeName);
            _hipsCorrectiveShapeIndexes[(int)FukaHipsCorrectiveShapeID.csAnusX150] = mesh.sharedMesh.GetBlendShapeIndex(hipsCorrectiveShapeConfig.X150AnusBlendShapeName);

            for (int i = 0; i < (int)FukaHipsCorrectiveShapeID.Count; i++) {
                if (_hipsCorrectiveShapeIndexes[i] <= 0) {
                    ErrorHandleService.Fatal($"FukaHipsCorrectiveShapeID {(FukaHipsCorrectiveShapeID)i} が見つかりません。IFukaHipsCorrectiveShapeConfigのブレンドシェイプ名を確認してください。");
                }
            }
        }

        public int Get(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) => _hipsCorrectiveShapeIndexes[(int)hipsCorrectiveShapeID];
    }
}