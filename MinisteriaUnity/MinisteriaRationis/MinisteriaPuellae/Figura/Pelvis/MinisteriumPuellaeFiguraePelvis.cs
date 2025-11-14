using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna

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

        public float LegoPondus(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) {
            int index = _tabula.Lego(hipsCorrectiveShapeID);
            return _hipsMesh.GetBlendShapeWeight(index);
        }

        public void PonoPondus(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID, float pondus) {
            int index = _tabula.Lego(hipsCorrectiveShapeID);
            _hipsMesh.SetBlendShapeWeight(index, pondus);
        }
    }
}