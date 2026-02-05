using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeFiguraeGenusLegibile : IOstiumPuellaeFiguraeGenusLegibile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusLegibile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAEFIGURAEGENUSLEGIBILE_INSTANCE_NULL);
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


