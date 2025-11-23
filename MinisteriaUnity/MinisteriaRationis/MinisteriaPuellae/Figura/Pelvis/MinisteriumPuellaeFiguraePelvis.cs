using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFiguraePelvis {
        private readonly SkinnedMeshRenderer _hipsMesh;
        private readonly TabulaPuellaeFiguraePelvis _tabula;

        public MinisteriumPuellaeFiguraePelvis(
            IConfiguratioPuellaeFiguraePelvis config
        ) {
            _hipsMesh = config.Mesh.EvolvareNuncium("MinisteriumPuellaeFiguraePelvis mesh is null.");
            _tabula = new TabulaPuellaeFiguraePelvis(config);
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
