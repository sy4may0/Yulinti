using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

using Yulinti.Dux.ContractusDucis;
namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraPuellaeCrinis : IAnchora, IPhantasma {
        IDPuellaeCrinis Typus { get; }
        Transform OsRadix { get; }
    }
}
