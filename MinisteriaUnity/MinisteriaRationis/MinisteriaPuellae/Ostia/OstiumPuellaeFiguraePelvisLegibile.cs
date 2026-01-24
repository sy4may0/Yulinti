using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeFiguraePelvisLegibile : IOstiumPuellaeFiguraePelvisLegibile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisLegibile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAEFIGURAEPELVISLEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }
        public float LegoPondus(IDPuellaeFiguraePelvis idFiguraePelvis) {
            return _miPuellaeFiguraePel.LegoPondus(idFiguraePelvis);
        }
    }
}


