using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeCrinis : IOrdinatioPuellae {
        IDPuellaeCrinis IdCrinis { get; }
    }
}