using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeStatusCorporisNavmesh : IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporisModiNavmesh IdModiNavmesh { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}