using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeRefrigeratio : StatusBasisCivisCustodiaePatrulatio {
        private readonly HorologiaCivisStatuumCustodiaeMutationis _horologiaCivisStatuumCustodiaeMutationis;

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Refrigeratio;

        public StatusCivisCustodiaeRefrigeratio(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivis ostiumCarrusCivis,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            HorologiaCivisStatuumCustodiaeMutationis horologiaCivisStatuumCustodiaeMutationis
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivis, ostiumTemporisLegibile) {
            _horologiaCivisStatuumCustodiaeMutationis = horologiaCivisStatuumCustodiaeMutationis;
        }

        public override void Intrare(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.ActivareRefrigerationem(idCivis);

            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Refrigeratio
            );
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareRefrigerationem(idCivis);
        }

        public override void Ordinare(int idCivis) {
            float dtSuspecta = -Configuratio.ConsumptioSuspectaeBasis * Temporis.Intervallum;
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: dtSuspecta
            );
            PurgereIntentionem(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaRefrigerationis(idCivis, Temporis.Intervallum)) {
                return IDCivisStatusCustodiae.Circumitus;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
