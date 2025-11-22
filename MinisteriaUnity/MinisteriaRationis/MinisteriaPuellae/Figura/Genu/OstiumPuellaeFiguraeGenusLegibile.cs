using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeFiguraeGenusLegibile : IOstiumPuellaeFiguraeGenusLegibile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusLegibile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのインスタンスがnullです。");
            }
            _miPuellaeFiguraeGenus = miPuellaeFiguraeGenus;
        }
        public float LegoPondus(IDPuellaeFiguraeGenus idFiguraeGenus) {
            return _miPuellaeFiguraeGenus.LegoPondus(idFiguraeGenus);
        }
    }
}

