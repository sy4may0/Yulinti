using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisAditoriumAdAditorium : IRamusCivisNavmesh {
        public IDCivisStatusNavmesh IdStatusActualis => IDCivisStatusNavmesh.Aditorium;
        public IDCivisStatusNavmesh IdStatusProximus => IDCivisStatusNavmesh.Aditorium;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            return CondicioCivisNavmesh.EstAdPerveni(contextusOstiorum, contextusResFluida);
        }
    }
}