using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
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
                    contextusOstiorum,
                    contextusOstiorum.Configuratio.Statuum
                );
            }
        }

        public void Initare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Fundamentum,
                _contextusOstiorum.Configuratio.Statuum.IdAnimationisPraedefinitus
            );

            // 初期位置へ移動（Puellae同様、MachinaではなくMiles側で要求する）。
            PostulareNavmeshIncipalis(idCivis);

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
            _machinaCorporis[idCivis].Mutare(resFluida);
            _machinaCorporis[idCivis].ConfirmareMutare(resFluida);
        }

        private void PostulareNavmeshIncipalis(int idCivis) {
            if (!_contextusOstiorum.PunctumViae.ConareLegoNatoriumTemere(out IPunctumViaeLegibile punctumViae)) {
                _contextusOstiorum.Carrus.PostulareMortis(
                    idCivis,
                    SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }

            _contextusOstiorum.Carrus.PostulareNavmesh(
                idCivis,
                punctumViae.Positio,
                true,
                0f,
                0f,
                0,
                0f
            );
        }
    }
}
