using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Auctoritas.Contractus {
    public interface IOperatioPortusConstructionisLapsorFaciei {
        void Executare(UsusPortusConstructionisLapsorFaciei usus);
        void Executare(UsusPortusConstructionisLapsorFaciei usus, float valor);
    }

    public interface IOperatioPortusConstructionisPulsabulumCrinisAnterior {
        void Executare(IDPuellaeCrinisCollectionisAnterior crinisAnterior);
    }

    public interface IOperatioPortusConstructionisPulsabulumCrinisPosterior {
        void Executare(IDPuellaeCrinisCollectionisPosterior crinisPosterior);
    }
}
