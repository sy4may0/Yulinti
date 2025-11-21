using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeFiguraeGenusMutabile : IOstiumPuellaeFiguraeGenusMutabile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusMutabile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのインスタンスがnullです。");
            }
            _miPuellaeFiguraeGenus = miPuellaeFiguraeGenus;
        }

        public void PonoPondus(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus) {
            _miPuellaeFiguraeGenus.PonoPondus(idFiguraeGenus, pondus);
        }
    }
}

