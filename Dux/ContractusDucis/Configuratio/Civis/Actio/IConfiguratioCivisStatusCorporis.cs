using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDCivisAnimationis IdAnimationisIntrare { get; }
        IDCivisAnimationis IdAnimationisExire { get; }
        bool LudereExire { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        float Deceleratio { get; }
        bool EstLevigatum { get; }
    }
}