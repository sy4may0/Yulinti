using System.Numerics;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociNavmeshLegibile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        bool EstAdPerveni(int id);
        bool EstMigrare(int id);
        float VelocitasHorizontalisActualis(int id);
        float VelocitasVerticalisActualis(int id);
        float RotatioYActualis(int id);
        float LegoVelocitatem(int id);
        float LegoAccelerationem(int id);
        float LegoDistantiaDeaccelerationis(int id);
        int LegoVelocitatemRotationisDeg(int id);
        Vector3 Positio(int id);
        Quaternion Rotatio(int id);
    }
}
