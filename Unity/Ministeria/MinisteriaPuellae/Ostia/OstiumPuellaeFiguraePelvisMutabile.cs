using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeFiguraePelvisMutabile : IOstiumPuellaeFiguraePelvisMutabile {
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePel;
        public OstiumPuellaeFiguraePelvisMutabile(MinisteriumPuellaeFiguraePelvis miPuellaeFiguraePel) {
            if (miPuellaeFiguraePel == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeFiguraePelvisMutabile_OSTIUMPUELLAEFIGURAEPELVISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeFiguraePel = miPuellaeFiguraePel;
        }

        public void PonoPondus(IDPuellaeFiguraePelvis idFiguraePelvis, float pondus) {
            _miPuellaeFiguraePel.PonoPondus(idFiguraePelvis, pondus);
        }
    }
}


