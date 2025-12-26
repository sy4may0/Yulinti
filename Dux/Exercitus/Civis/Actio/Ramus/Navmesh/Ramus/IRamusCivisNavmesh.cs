using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusCivisNavmesh : IRamusCivis {
        IDCivisStatusNavmesh IdStatusActualis { get; }
        IDCivisStatusNavmesh IdStatusProximus { get; }
    }
}