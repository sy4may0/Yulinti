using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeQuaerens : StatusBasisCivisCustodiaePatrulatio {
        private readonly HorologiaCivisStatuumCustodiaeMutationis _horologiaCivisStatuumCustodiaeMutationis;

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Quaerens;

        public StatusCivisCustodiaeQuaerens(
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
            _horologiaCivisStatuumCustodiaeMutationis.ActivareQuaerentem(idCivis);

            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Quaerens
            );
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareQuaerentem(idCivis);
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
            PurgereIntentionem(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // Circumitusと同様。ただしQuaerens開始時点でSuspectaが100%に残っている場合があるため、再視認を条件とする。
            if (EstSuspectaPlena(idCivis) && ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                if (EstExcessusAnomaliaeVisae(idCivis)) {
                    return IDCivisStatusCustodiae.Discedens;
                }
                return IDCivisStatusCustodiae.Vigilantia;
            }

            if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaQuaerentis(idCivis, Temporis.Intervallum)) {
                return IDCivisStatusCustodiae.Circumitus;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
