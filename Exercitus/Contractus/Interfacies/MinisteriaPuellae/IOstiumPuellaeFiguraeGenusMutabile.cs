using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumPuellaeFiguraeGenusMutabile {
        void PonoPondusDexter(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus);
        void PonoPondusSinister(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus);
    }
}



