using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeVigilantia : StatusBasisCivisCustodiaePatrulatio {

        private readonly HorologiaCivisStatuumCustodiaeMutationis _horologiaCivisStatuumCustodiaeMutationis;

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Vigilantia;

        public StatusCivisCustodiaeVigilantia(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivisVeletudinis ostiumCarrusCivisVeletudinis,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            HorologiaCivisStatuumCustodiaeMutationis horologiaCivisStatuumCustodiaeMutationis
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile) {
            _horologiaCivisStatuumCustodiaeMutationis = horologiaCivisStatuumCustodiaeMutationis;
        }

        public override void Intrare(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.ActivareVigilantiam(idCivis);

            CarrusVeletudinis.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Vigilantia
            );
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareVigilantiam(idCivis);
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
            PurgereIntentionem(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // horologium時間が経過した時
            if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaVigilantiae(idCivis, Temporis.Intervallum)) {
                return IDCivisStatusCustodiae.Spectans;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
