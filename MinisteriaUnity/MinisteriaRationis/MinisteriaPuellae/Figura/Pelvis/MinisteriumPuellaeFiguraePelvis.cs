using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeFiguraePelvis {
        private readonly SkinnedMeshRenderer _hipsMesh;
        private readonly TabulaFiguraePelvis _tabula;

        public MinisteriumPuellaeFiguraePelvis(
            IConfiguratioPuellaeFiguraePelvis config
        ) {
            if (config.Mesh == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraePelvisのConfiguratioPuellaeFiguraePelvisのMeshがnullです。");
            }
            _hipsMesh = config.Mesh;
            _tabula = new TabulaFiguraePelvis(config);
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