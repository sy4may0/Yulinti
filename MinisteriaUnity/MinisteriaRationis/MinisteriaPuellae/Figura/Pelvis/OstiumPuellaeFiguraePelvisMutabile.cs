using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeFiguraePelvisMutabile : IOstiumPuellaeFiguraePelvisMutabile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisMutabile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraePelvisのインスタンスがnullです。");
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }

        public void PonoPondus(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID, float pondus) {
            _miPuellaeFiguraePel.PonoPondus(hipsCorrectiveShapeID, pondus);
        }
    }
}