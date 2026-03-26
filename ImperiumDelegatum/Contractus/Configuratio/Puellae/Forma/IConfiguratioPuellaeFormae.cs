using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioPuellaeFormae {
        IDPuellaeFormae Id { get; }

        Vector3 MagnitudoMaxima { get; }
        Vector3 MagnitudoMedia { get; }
        Vector3 MagnitudoMinima { get; }

        IDPuellaeOssis[] Ossa { get; }
    }
}