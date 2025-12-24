using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporis Id { get; }
        IDCivisAnimationisContinuata IdAnimationisIntrare { get; }
        IDCivisAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
        int ConsumptioVitae { get; }

        // Navmesh設定
        bool EstNavMesh { get; }
        IDCivisModiNavmesh IdModiNavmesh { get; }
        float VelocitasDesiderata { get; }
        float Acceleratio { get; }
        int VelocitasRotationis { get; }
        float DistantiaDeaccelerationis { get; }

        // 非Navmesh設定
        IDCivisModiMotus IdModiMotus { get; }
    }
}