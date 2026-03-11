using UnityEngine;

namespace Yulinti.Officia.Contractus {
    public interface IAnchora {
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
        Vector3 Scala { get; }
        bool Validare();
    }
}
