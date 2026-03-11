using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioPuellaeStatusCorporisMotus : IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporisModiMotus IdModiMotus { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        float Deceleratio { get; }
        bool EstLevigatum { get; }
    }
}