using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisActionis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumPunctumViaeLegibile _punctumViae;
        private readonly MachinaCivisStatuumCorporis[] _machinaCorporis;

        public MilesCivisActionis(
            IOstiumCarrusCivis carrus,
            IOstiumCivisAnimationesLegibile animationis,
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumPunctumViaeLegibile punctumViae,
            ContextusStatusCivisCorporis contextusStatusCivisCorporis,
            ContextusRamusCivis contextusRamusCivis,
            IConfiguratioCivisStatuum configuratioStatuum
        ) {
            _configuratioStatuum = configuratioStatuum;
            _carrus = carrus;
            _punctumViae = punctumViae;
            
            _machinaCorporis = new MachinaCivisStatuumCorporis[ostiumCivisLegibile.Longitudo];
            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _machinaCorporis[i] = new MachinaCivisStatuumCorporis(
                    i,
                    carrus,
                    animationis,
                    contextusRamusCivis,
                    contextusStatusCivisCorporis,
                    configuratioStatuum
                );
            }
        }

        public void Initare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Fundamentum,
                _configuratioStatuum.IdAnimationisPraedefinitus
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
            if (!_punctumViae.ConareLegoNatoriumTemere(out IPunctumViaeLegibile punctumViae)) {
                _carrus.PostulareMortis(
                    idCivis,
                    SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }

            _carrus.PostulareNavmesh(
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
