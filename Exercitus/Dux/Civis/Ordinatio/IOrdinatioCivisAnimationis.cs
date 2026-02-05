using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Dux {
    internal interface IOrdinatioCivisAnimationis : IOrdinatioCivis {
        IDCivisAnimationisContinuata IdAnimationis { get; }
        Action AdInitium { get; }
        Action AdFinem { get; }
        bool EstCogere { get; }
    }
}