using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisCorporisMigrareAditoriumAdMigrareCrematorium : IRamusCivisCorporis {
        public IDCivisStatusCorporis IdStatusActualis => IDCivisStatusCorporis.MigrareAditorium;
        public IDCivisStatusCorporis IdStatusProximus => IDCivisStatusCorporis.MigrareCrematorium;
        public int Prioritas => 0;
        public bool Condicio(
            int idCivis,
            ContextusCivisOstiorumLegibile contextus,
            IResFluidaCivisLegibile resFluida
        ) {
            // Navmesh到達時に寿命が尽きていたらMigrareCrematoriumに遷移
            return CondicioCivisNavmesh.EstAdPerveni(idCivis, contextus) &&
                   CondicioCivisVeletudinis.EstExhauritaVitae(idCivis, resFluida);
        }

    }
}