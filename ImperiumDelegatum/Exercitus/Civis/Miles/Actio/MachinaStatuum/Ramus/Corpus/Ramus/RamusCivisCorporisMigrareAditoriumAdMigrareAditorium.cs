using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class RamusCivisCorporisMigrareAditoriumAdMigrareAditorium : IRamusCivisCorporis {
        public IDCivisStatusCorporis IdStatusActualis => IDCivisStatusCorporis.MigrareAditorium;
        public IDCivisStatusCorporis IdStatusProximus => IDCivisStatusCorporis.MigrareAditorium;
        public int Prioritas => 1000;
        public bool Condicio(
            int idCivis,
            ContextusCivisOstiorumLegibile contextus,
            IResFluidaCivisLegibile resFluida
        ) {
            return CondicioCivisNavmesh.EstAdPerveni(idCivis, contextus);
        }
    }
}