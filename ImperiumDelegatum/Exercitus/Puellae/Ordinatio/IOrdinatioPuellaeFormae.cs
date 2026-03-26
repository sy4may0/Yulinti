using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeFormae : IOrdinatioPuellae {
        IDPuellaeFormae IdFormae { get; }
        Vector3 MagnitudoDesiderata { get; }
    }
}