using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Figura.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeFiguraeGenus {
        private readonly SkinnedMeshRenderer _kneeMesh;
        private readonly TabulaFiguraeGenus _tabula;

        public MinisteriumPuellaeFiguraeGenus(
            IConfiguratioPuellaeFiguraeGenus config
        ) {
            if (config.Mesh == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのConfiguratioPuellaeFiguraeGenusのMeshがnullです。");
            }
            _kneeMesh = config.Mesh;
            _tabula = new TabulaFiguraeGenus(config);
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
