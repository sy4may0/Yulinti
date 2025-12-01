using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
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


