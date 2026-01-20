using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFiguraePelvis {
        private readonly SkinnedMeshRenderer _hipsMesh;
        private readonly TabulaPuellaeFiguraePelvis _tabula;

        public MinisteriumPuellaeFiguraePelvis(
            IConfiguratioPuellaeFiguraePelvis config,
            IAnchoraPuellae anchora
        ) {
            _hipsMesh = anchora.FiguraPelvis;
            _tabula = new TabulaPuellaeFiguraePelvis(config, _hipsMesh);
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


