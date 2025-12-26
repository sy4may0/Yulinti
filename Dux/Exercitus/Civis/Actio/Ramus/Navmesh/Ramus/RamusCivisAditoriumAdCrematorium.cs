using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisAditoriumAdCrematorium : IRamusCivisNavmesh {
        public IDCivisStatusNavmesh IdStatusActualis => IDCivisStatusNavmesh.Aditorium;
        public IDCivisStatusNavmesh IdStatusProximus => IDCivisStatusNavmesh.Crematorium;
        public int Prioritas => 0;
        public bool Condicio(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            return CondicioCivisNavmesh.EstAdPerveni(contextusOstiorum, contextusResFluida);
        }
    }
}