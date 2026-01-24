using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusCorporisMotus : IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporisModiMotus IdModiMotus { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        float Deceleratio { get; }
        bool EstLevigatum { get; }
    }
}