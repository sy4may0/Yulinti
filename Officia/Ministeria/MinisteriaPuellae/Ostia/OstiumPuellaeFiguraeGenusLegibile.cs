using Yulinti.Officia.Ministeria;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeFiguraeGenusLegibile : IOstiumPuellaeFiguraeGenusLegibile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusLegibile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeFiguraeGenusLegibile_OSTIUMPUELLAEFIGURAEGENUSLEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeFiguraeGenus = miPuellaeFiguraeGenus;
        }
        public float LegoPondusDexter(IDPuellaeFiguraeGenus idFiguraeGenus) {
            return _miPuellaeFiguraeGenus.LegoPondusDexter(idFiguraeGenus);
        }
        public float LegoPondusSinister(IDPuellaeFiguraeGenus idFiguraeGenus) {
            return _miPuellaeFiguraeGenus.LegoPondusSinister(idFiguraeGenus);
        }
    }
}


