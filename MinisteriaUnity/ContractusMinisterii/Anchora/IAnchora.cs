using UnityEngine;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchora {
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
        Vector3 Scala { get; }
        bool Validare();
    }
}
