using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeFiguraePelvisMutabile : IOstiumPuellaeFiguraePelvisMutabile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisMutabile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraePelvisのインスタンスがnullです。");
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }

        public void PonoPondus(IDPuellaeFiguraePelvis idFiguraePelvis, float pondus) {
            _miPuellaeFiguraePel.PonoPondus(idFiguraePelvis, pondus);
        }
    }
}