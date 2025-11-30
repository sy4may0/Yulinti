using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraPunctumViae : IAnchora {
        IDPunctumViaeTypi Typus { get; }
        GameObject[] PunctaViaeConsequens { get; }
    }
}
