using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeAnimationis : IOrdinatioPuellae {
        IDPuellaeAnimationisContinuata IdAnimationis { get; }
        Action AdInitium { get; }
        Action AdFinem { get; }
        bool EstCogere { get; }
    }
}