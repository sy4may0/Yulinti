using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusCorporisNavmesh : IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporisModiNavmesh IdModiNavmesh { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}