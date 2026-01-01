using Yulinti.MinisteriaUnity.ContractusMinisterii;
namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusCorporisNavmesh : IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporisModiNavmesh IdModiNavmesh { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}