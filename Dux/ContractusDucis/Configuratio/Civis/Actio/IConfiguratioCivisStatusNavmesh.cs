using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusNavmesh {
        IDCivisStatusNavmesh Id { get; }
        IDCivisAnimationisContinuata IdAnimationisIntrare { get; }
        IDCivisAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
        int ConsumptioVitae { get; }

        // Navmesh設定
        IDCivisModiNavmesh IdModiNavmesh { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }
    }
}