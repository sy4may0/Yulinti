using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeCrinisCollectionisAnterior : IOrdinatioPuellae {
        IDPuellaeCrinisCollectionisAnterior IdCrinisCollectionisAnterior { get; }
    }

    internal interface IOrdinatioPuellaeCrinisCollectionisPosterior : IOrdinatioPuellae {
        IDPuellaeCrinisCollectionisPosterior IdCrinisCollectionisPosterior { get; }
    }
}
