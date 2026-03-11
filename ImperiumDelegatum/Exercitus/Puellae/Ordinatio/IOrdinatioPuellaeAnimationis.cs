using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeAnimationis : IOrdinatioPuellae {
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationis IdAnimationis { get; }
    }
}