using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeFiguraeGenusLegibile : IOstiumPuellaeFiguraeGenusLegibile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusLegibile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraeGenusのインスタンスがnullです。");
            }
            _miPuellaeFiguraeGenus = miPuellaeFiguraeGenus;
        }
        public float LegoPondus(FukaKneeCorrectiveShapeID kneeCorrectiveShapeID) {
            return _miPuellaeFiguraeGenus.LegoPondus(kneeCorrectiveShapeID);
        }
    }
}

