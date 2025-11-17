using Yulinti.MinisteriaUnity.Interna;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeFiguraePelvisMutabile : IOstiumPuellaeFiguraePelvisMutabile {
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