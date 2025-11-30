using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraPuellaeCrinis : IAnchora, IPhantasma {
        IDPuellaeCrinis Typus { get; }
        Transform OsRadix { get; }
    }
}
