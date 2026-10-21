using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeCrinisBasis : IOrdinatioPuellae {
        IDPuellaeCrinisBasis IdCrinisBasis { get; }
    }

    internal interface IOrdinatioPuellaeCrinisAnterior : IOrdinatioPuellae {
        IDPuellaeCrinisAnterior IdCrinisAnterior { get; }
    }

    internal interface IOrdinatioPuellaeCrinisPosterior : IOrdinatioPuellae {
        IDPuellaeCrinisPosterior IdCrinisPosterior { get; }
    }
}
