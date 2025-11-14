using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeFiguraePelvisLegibile : IOstiumPuellaeFiguraePelvisLegibile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisLegibile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeFiguraePelvisのインスタンスがnullです。");
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }
        public float LegoPondus(FukaHipsCorrectiveShapeID hipsCorrectiveShapeID) {
            return _miPuellaeFiguraePel.LegoPondus(hipsCorrectiveShapeID);
        }
    }
}