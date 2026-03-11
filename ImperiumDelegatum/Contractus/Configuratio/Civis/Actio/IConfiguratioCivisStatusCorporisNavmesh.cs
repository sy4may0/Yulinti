using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisStatusCorporisNavmesh : IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporisModiNavmesh IdModiNavmesh { get; }
        IDPunctumViaeTypi TypusPunctumViae { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}