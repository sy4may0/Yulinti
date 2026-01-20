using UnityEngine;

using Yulinti.Dux.ContractusDucis;
namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IAnchoraPunctumViae : IAnchora {
        IDPunctumViaeTypi Typus { get; }
    }
}
