using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeRelationisTerrae {
        NihilAut<Transform> LeftFoot { get; }
        NihilAut<Transform> LeftToe { get; }
        NihilAut<Transform> RightFoot { get; }
        NihilAut<Transform> RightToe { get; }
        NihilAut<LayerMask> RaycastStratum { get; }
    }
}
