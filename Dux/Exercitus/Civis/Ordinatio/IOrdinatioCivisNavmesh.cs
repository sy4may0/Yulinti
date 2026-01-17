using System.Numerics;
namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioCivisNavmesh : IOrdinatioCivis {
        Vector3 Positio { get; }
        // Migrareで移動するか、Transportoでワープするかを判定するフラグ
        bool EstTransporto { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}