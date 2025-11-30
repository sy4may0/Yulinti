using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeRelationisTerrae {
        NihilAut<LayerMask> RaycastStratum { get; }
    }
}
