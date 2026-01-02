using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisCorporisNativitasAdMigrareAditorium : IRamusCivisCorporis {
        public IDCivisStatusCorporis IdStatusActualis => IDCivisStatusCorporis.Nativitas;
        public IDCivisStatusCorporis IdStatusProximus => IDCivisStatusCorporis.MigrareAditorium;
        public int Prioritas => 0;
        public bool Condicio(
            int idCivis,
            ContextusCivisOstiorumLegibile contextus,
            IResFluidaCivisLegibile resFluida
        ) {
            // 生成後無条件にMigrareAditoriumに遷移
            return true;
        }
    }
}