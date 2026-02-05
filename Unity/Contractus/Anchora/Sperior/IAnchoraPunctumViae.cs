using UnityEngine;

using Yulinti.Exercitus.Contractus;
namespace Yulinti.Unity.Contractus {
    public interface IAnchoraPunctumViae : IAnchora {
        IDPunctumViaeTypi Typus { get; }
    }
}
