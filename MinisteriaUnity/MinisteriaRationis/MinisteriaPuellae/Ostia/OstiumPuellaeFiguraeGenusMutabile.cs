using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
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


