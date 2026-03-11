using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.Officia.Contractus;

using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.Officia.Contractus {
    public interface IAnchoraPuellaeCrinis : IAnchora, IPhantasma {
        IDPuellaeCrinis Typus { get; }
        Transform OsRadix { get; }
    }
}
