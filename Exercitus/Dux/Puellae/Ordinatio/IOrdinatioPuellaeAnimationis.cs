using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Dux {
    internal interface IOrdinatioPuellaeAnimationis : IOrdinatioPuellae {
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationis IdAnimationis { get; }
    }
}