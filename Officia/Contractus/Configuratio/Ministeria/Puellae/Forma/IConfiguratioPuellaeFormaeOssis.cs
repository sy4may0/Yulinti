using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioPuellaeFormaeOssis {
        IDPuellaeFormae Forma { get; }
        IDRedittorPuellaeOssisCorrectorium[] Scopus { get; }

        Vector3 MagnitudoMaxima { get; }
        Vector3 MagnitudoMedia { get; }
        Vector3 MagnitudoMinima { get; }
    }
}