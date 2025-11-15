using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeFiguraePelvis {
        private readonly SkinnedMeshRenderer _hipsMesh;
        private readonly TabulaFiguraePelvis _tabula;

        public MinisteriumPuellaeFiguraePelvis(
            IFukaHipsCorrectiveShapeConfig hipsCorrectiveShapeConfig
        ) {
            if (hipsCorrectiveShapeConfig.Mesh == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraePelvisのHipsCorrectiveShapeConfigのMeshがnullです。");
            }
            _hipsMesh = hipsCorrectiveShapeConfig.Mesh;
            _tabula = new TabulaFiguraePelvis(hipsCorrectiveShapeConfig);
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