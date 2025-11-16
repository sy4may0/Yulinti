using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeRelationisTerrae {
        Transform LeftFoot { get; }
        Transform LeftToe { get; }
        Transform RightFoot { get; }
        Transform RightToe { get; }
    }
}