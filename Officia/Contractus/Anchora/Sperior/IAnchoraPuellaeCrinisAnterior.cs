using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.Officia.Contractus;

using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.Officia.Contractus {
    public interface IAnchoraPuellaeCrinisAnterior : IAnchora, IPhantasma {
        IDPuellaeCrinisAnterior Typus { get; }
        Transform OsRadix { get; }
        void Activare();
        void Deactivare();
    }
}
