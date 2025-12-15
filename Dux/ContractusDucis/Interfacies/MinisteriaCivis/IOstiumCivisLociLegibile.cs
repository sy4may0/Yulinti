using System.Numerics;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociLegibile {
        bool EstAdPerveni { get; }
        bool EstMigrare { get; }
        float VelocitasHorizontalisActualis { get; }
        float VelocitasVerticalisActualis { get; }
        float RotatioYActualis { get; }
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
    }
}