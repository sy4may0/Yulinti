using UnityEngine;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraPunctumViae : IAnchora {
        IDPunctumViaeTypi Typus { get; }
    }
}
