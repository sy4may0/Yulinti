using System.Numerics;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociLegibile {
        bool EstActivum { get; }
        bool EstAdPerveni { get; }
        float VelocitasHorizontalisActualis { get; }
        float VelocitasVerticalisActualis { get; }
        float RotatioYActualis { get; }
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
    }
}