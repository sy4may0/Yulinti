using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeFiguraeGenus {
        private readonly int[] _figuraeIndexes;

        public TabulaPuellaeFiguraeGenus(IConfiguratioPuellaeFiguraeGenus config, SkinnedMeshRenderer mesh) {
            int longitudo = Enum.GetNames(typeof(IDPuellaeFiguraeGenus)).Length;
            _figuraeIndexes = new int[longitudo];

            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee90] = mesh.sharedMesh.GetBlendShapeIndex(config.X90BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee150] = mesh.sharedMesh.GetBlendShapeIndex(config.X150BlendShapeName);
            _figuraeIndexes[(int)IDPuellaeFiguraeGenus.csknee120Offset] = mesh.sharedMesh.GetBlendShapeIndex(config.X120OffsetBlendShapeName);

            for (int i = 0; i < longitudo; i++) {
                if (_figuraeIndexes[i] <= 0) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEFIGURAEGENUS_BLEND_SHAPE_NOT_FOUND);
                }
            }
        }

        public int Lego(IDPuellaeFiguraeGenus idFiguraeGenus) => _figuraeIndexes[(int)idFiguraeGenus];
    }
}


