using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFiguraeGenus {
        private readonly SkinnedMeshRenderer _kneeMesh;
        private readonly TabulaPuellaeFiguraeGenus _tabula;

        public MinisteriumPuellaeFiguraeGenus(
            IConfiguratioPuellaeFiguraeGenus config, 
            SkinnedMeshRenderer kneeMesh
        ) {
            _kneeMesh = kneeMesh;
            _tabula = new TabulaPuellaeFiguraeGenus(config, kneeMesh);
        }

        public float LegoPondus(IDPuellaeFiguraeGenus idFiguraeGenus) {
            int index = _tabula.Lego(idFiguraeGenus);
            return _kneeMesh.GetBlendShapeWeight(index);
        }

        public void PonoPondus(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus) {
            int index = _tabula.Lego(idFiguraeGenus);
            _kneeMesh.SetBlendShapeWeight(index, pondus);
        }
    }
}


