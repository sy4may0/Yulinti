using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.SMR.Internal;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeFiguraeGenus {
        private readonly SkinnedMeshRenderer _kneeMesh;
        private readonly TabulaFiguraeGenus _tabula;

        public MinisteriumPuellaeFiguraeGenus(
            IFukaKneeCorrectiveShapeConfig kneeCorrectiveShapeConfig
        ) {
            if (kneeCorrectiveShapeConfig.Mesh == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのKneeCorrectiveShapeConfigのMeshがnullです。");
            }
            _kneeMesh = kneeCorrectiveShapeConfig.Mesh;
            _tabula = new TabulaFiguraeGenus(kneeCorrectiveShapeConfig);
        }
        public float LegoPondus(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) {
            int index = _tabula.Lego(kneeCorrectiveShapeID);
            return _kneeMesh.GetBlendShapeWeight(index);
        }
        public void PonoPondus(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID, float pondus) {
            int index = _tabula.Lego(kneeCorrectiveShapeID);
            _kneeMesh.SetBlendShapeWeight(index, pondus);
        }
    }
}
