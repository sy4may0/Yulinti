using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFiguraePelvis {
        private readonly SkinnedMeshRenderer _hipsMesh;
        private readonly TabulaPuellaeFiguraePelvis _tabula;

        public MinisteriumPuellaeFiguraePelvis(
            IConfiguratioPuellaeFiguraePelvis config,
            SkinnedMeshRenderer hipsMesh
        ) {
            _hipsMesh = hipsMesh;
            _tabula = new TabulaPuellaeFiguraePelvis(config, hipsMesh);
        }

        public float LegoPondus(IDPuellaeFiguraePelvis idFiguraePelvis) {
            int index = _tabula.Lego(idFiguraePelvis);
            return _hipsMesh.GetBlendShapeWeight(index);
        }

        public void PonoPondus(IDPuellaeFiguraePelvis idFiguraePelvis, float pondus) {
            int index = _tabula.Lego(idFiguraePelvis);
            _hipsMesh.SetBlendShapeWeight(index, pondus);
        }
    }
}


