using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeAnimationis : IOrdinatioPuellae {
        IDPuellaeAnimationisContinuata IdAnimationis { get; }
        Action AdInitium { get; }
        Action AdFinem { get; }
        bool EstCogere { get; }

        void Pono(
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        );
    }
}