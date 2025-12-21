using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDPuellaeModiMotus IdModusMotus { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        float Deceleratio { get; }
        bool EstLevigatum { get; }
    }
}