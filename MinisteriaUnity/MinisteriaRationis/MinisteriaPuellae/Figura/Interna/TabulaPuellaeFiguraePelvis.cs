using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeFiguraePelvis {
        private readonly int[] _figuraeIndexes;

        public TabulaPuellaeFiguraePelvis(IConfiguratioPuellaeFiguraePelvis config) {
            _figuraeIndexes = new int[(int)IDPuellaeFiguraePelvis.Count];
            SkinnedMeshRenderer mesh = config.Mesh.Evolvo(IDErrorum.TABULAPUELLAEFIGURAEPELVIS_MESH_NULL);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipX90] = mesh.sharedMesh.GetBlendShapeIndex(config.LeftX90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipX150] = mesh.sharedMesh.GetBlendShapeIndex(config.LeftX150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csLHipY90] = mesh.sharedMesh.GetBlendShapeIndex(config.LeftY90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipX90] = mesh.sharedMesh.GetBlendShapeIndex(config.RightX90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipX150] = mesh.sharedMesh.GetBlendShapeIndex(config.RightX150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csRHipY90] = mesh.sharedMesh.GetBlendShapeIndex(config.RightY90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraePelvis.csAnusX150] = mesh.sharedMesh.GetBlendShapeIndex(config.X150AnusBlendShapeName);

            for (int i = 0; i < (int)IDPuellaeFiguraePelvis.Count; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEFIGURAEPELVIS_BLEND_SHAPE_NOT_FOUND);
                }
            }
        }

        public int Lego(IDPuellaeFiguraePelvis idFiguraePelvis) => _figuraeIndexes[(int)idFiguraePelvis];
    }
}
