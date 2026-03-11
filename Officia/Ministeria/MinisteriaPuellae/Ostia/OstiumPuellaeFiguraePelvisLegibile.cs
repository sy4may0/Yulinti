using Yulinti.Officia.Ministeria;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeFiguraePelvisLegibile : IOstiumPuellaeFiguraePelvisLegibile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisLegibile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeFiguraePelvisLegibile_OSTIUMPUELLAEFIGURAEPELVISLEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }
        public float LegoPondus(IDPuellaeFiguraePelvis idFiguraePelvis) {
            return _miPuellaeFiguraePel.LegoPondus(idFiguraePelvis);
        }
    }
}


