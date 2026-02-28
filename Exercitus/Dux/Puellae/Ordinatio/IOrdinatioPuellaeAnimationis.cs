using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Dux {
    internal interface IOrdinatioPuellaeAnimationis : IOrdinatioPuellae {
        IDPuellaeAnimationisContinuata IdAnimationis { get; }
        Action AdInitium { get; }
        Action AdFinem { get; }
        bool EstCogere { get; }
    }
}