using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioCivisAnimationis : IOrdinatioCivis {
        IDCivisAnimationisContinuata IdAnimationis { get; }
        Action AdInitium { get; }
        Action AdFinem { get; }
        bool EstCogere { get; }
    }
}