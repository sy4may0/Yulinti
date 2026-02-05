using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeFiguraeGenusMutabile : IOstiumPuellaeFiguraeGenusMutabile {
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenus;
        public OstiumPuellaeFiguraeGenusMutabile(MinisteriumPuellaeFiguraeGenus miPuellaeFiguraeGenus) {
            if (miPuellaeFiguraeGenus == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAEFIGURAEGENUSMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeFiguraeGenus = miPuellaeFiguraeGenus;
        }

        public void PonoPondusDexter(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus) {
            _miPuellaeFiguraeGenus.PonoPondusDexter(idFiguraeGenus, pondus);
        }
        public void PonoPondusSinister(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus) {
            _miPuellaeFiguraeGenus.PonoPondusSinister(idFiguraeGenus, pondus);
        }
    }
}


