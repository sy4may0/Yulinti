using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly MachinaPuellaeStatuumCorporis _machinaCorporis;

        public MilesPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _machinaCorporis = new MachinaPuellaeStatuumCorporis(
                _contextusOstiorum
            );
        }

        // [TODO] Nevmeshから外れた時のリカバリがきえちゃった

        public void Initare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaCorporis.Initare(resFluida);
        }

        public void Ordinare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaCorporis.Ordinare(resFluida);
        }

        public void MutareStatus(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaCorporis.MutareStatus(resFluida);
        }
    }
}
