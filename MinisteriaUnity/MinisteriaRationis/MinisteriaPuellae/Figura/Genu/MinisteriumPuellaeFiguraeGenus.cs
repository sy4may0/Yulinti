using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna;

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
