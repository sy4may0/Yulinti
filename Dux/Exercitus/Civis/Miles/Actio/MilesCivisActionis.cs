using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisActionis {
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;
        private readonly MachinaCivisStatuumCorporis[] _machinaCorporis;

        public MilesCivisActionis(
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _machinaCorporis = new MachinaCivisStatuumCorporis[contextusOstiorum.Civis.Longitudo];
            for (int i = 0; i < contextusOstiorum.Civis.Longitudo; i++) {
                _machinaCorporis[i] = new MachinaCivisStatuumCorporis(
                    i,
                    contextusOstiorum
                );
            }
        }

        public void Initare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis,
                _contextusOstiorum.Configuratio.Statuum.IdAnimationisPraedefinitus,
                null,
                null,
                true
            );
            _machinaCorporis[idCivis].Initare(resFluida);
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _machinaCorporis[idCivis].Ordinare(resFluida);
        }

        public void MutareStatus(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _machinaCorporis[idCivis].MutareStatus(resFluida);
        }
    }
}
