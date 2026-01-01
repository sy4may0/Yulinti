using System.Numerics;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeLociNavmeshLegibile {
        bool EstActivum();
        bool EstAdPerveni();
        float VelocitasHorizontalisActualis();
        float VelocitasVerticalisActualis();
        float RotatioYActualis();
        float LegoVelocitatem();
        float LegoAccelerationem();
        float LegoDistantiaDeaccelerationis();
        int LegoVelocitatemRotationisDeg();
        Vector3 Positio();
        Quaternion Rotatio();
    }
}
