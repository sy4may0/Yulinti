using System.Numerics;

namespace Yulinti.Exercitus.Dux {
    internal interface IOrdinatioPuellaeNavmeshInitii : IOrdinatioPuellaeInitii {
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
    }
}
