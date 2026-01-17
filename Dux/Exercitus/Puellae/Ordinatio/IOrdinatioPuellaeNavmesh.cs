using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeNavmesh : IOrdinatioPuellae {
        Vector3 Positio { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        float VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}