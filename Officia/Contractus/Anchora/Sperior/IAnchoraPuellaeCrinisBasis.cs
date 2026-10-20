using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.Officia.Contractus;

using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.Officia.Contractus {
    public interface IAnchoraPuellaeCrinisBasis : IAnchora {
        IDPuellaeCrinisBasis Typus { get; }
        void Activare();
        void Deactivare();
    }
}