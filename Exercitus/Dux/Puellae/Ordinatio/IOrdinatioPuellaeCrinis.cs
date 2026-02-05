using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IOrdinatioPuellaeCrinis : IOrdinatioPuellae {
        IDPuellaeCrinis IdCrinis { get; }
    }
}