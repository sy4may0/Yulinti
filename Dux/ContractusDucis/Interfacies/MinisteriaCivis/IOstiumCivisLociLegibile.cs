using System.Numerics;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociLegibile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        bool EstAdPerveni(int id);
        float VelocitasHorizontalisActualis(int id);
        float VelocitasVerticalisActualis(int id);
        float RotatioYActualis(int id);
        Vector3 Positio(int id);
        Quaternion Rotatio(int id);
    }
}