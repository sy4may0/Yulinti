using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisCrematoriumAdSuicidum : IRamusCivisNavmesh {
        public IDCivisStatusNavmesh IdStatusActualis => IDCivisStatusNavmesh.Crematorium;
        public IDCivisStatusNavmesh IdStatusProximus => IDCivisStatusNavmesh.Suicidium;
        public int Prioritas => 0;
        public bool Condicio(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            // SuicidumはIntareでDespawnされる。
            return CondicioCivisNavmesh.EstAdPerveni(contextusOstiorum, contextusResFluida);
        }
    }
}