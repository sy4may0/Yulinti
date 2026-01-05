using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisCorporisMigrareCrematoriumAdSuicidium : IRamusCivisCorporis {
        public IDCivisStatusCorporis IdStatusActualis => IDCivisStatusCorporis.MigrareCrematorium;
        public IDCivisStatusCorporis IdStatusProximus => IDCivisStatusCorporis.Suicidium;
        public int Prioritas => 0;
        public bool Condicio(
            int idCivis,
            ContextusCivisOstiorumLegibile contextus,
            IResFluidaCivisLegibile resFluida
        ) {
            // Crematrium到達でSuicidiumに遷移
            return CondicioCivisNavmesh.EstAdPerveni(idCivis, contextus);
        }
    }
}