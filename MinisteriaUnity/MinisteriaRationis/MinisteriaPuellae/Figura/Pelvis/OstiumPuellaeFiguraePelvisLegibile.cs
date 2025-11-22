using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeFiguraePelvisLegibile : IOstiumPuellaeFiguraePelvisLegibile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisLegibile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraePelvisのインスタンスがnullです。");
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }
        public float LegoPondus(IDPuellaeFiguraePelvis idFiguraePelvis) {
            return _miPuellaeFiguraePel.LegoPondus(idFiguraePelvis);
        }
    }
}