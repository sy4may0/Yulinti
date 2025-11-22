using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFiguraeGenus {
        private readonly SkinnedMeshRenderer _kneeMesh;
        private readonly TabulaPuellaeFiguraeGenus _tabula;

        public MinisteriumPuellaeFiguraeGenus(
            IConfiguratioPuellaeFiguraeGenus config
        ) {
            if (config.Mesh == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのConfiguratioPuellaeFiguraeGenusのMeshがnullです。");
            }
            _kneeMesh = config.Mesh;
            _tabula = new TabulaPuellaeFiguraeGenus(config);
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
