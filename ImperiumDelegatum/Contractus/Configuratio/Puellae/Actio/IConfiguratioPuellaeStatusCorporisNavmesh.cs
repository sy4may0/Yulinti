using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioPuellaeStatusCorporisNavmesh : IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporisModiNavmesh IdModiNavmesh { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}