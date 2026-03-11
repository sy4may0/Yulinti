using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeCrinis : IOrdinatioPuellae {
        IDPuellaeCrinis IdCrinis { get; }
    }
}