using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeFiguraeGenusMutabile : IOstiumPuellaeFiguraeGenusMutabile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusMutabile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのインスタンスがnullです。");
            }
            _miPuellaeFiguraeGenus = miPuellaeFiguraeGenus;
        }

        public void PonoPondus(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID, float pondus) {
            _miPuellaeFiguraeGenus.PonoPondus(kneeCorrectiveShapeID, pondus);
        }
    }
}

