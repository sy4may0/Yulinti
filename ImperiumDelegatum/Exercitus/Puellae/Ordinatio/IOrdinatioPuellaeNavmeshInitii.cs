using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeNavmeshInitii : IOrdinatioPuellaeInitii {
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
    }
}
