using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.Unity.Contractus;

using Yulinti.Exercitus.Contractus;
namespace Yulinti.Unity.Contractus {
    public interface IAnchoraPuellaeCrinis : IAnchora, IPhantasma {
        IDPuellaeCrinis Typus { get; }
        Transform OsRadix { get; }
    }
}
