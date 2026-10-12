using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

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
            IOstiumCarrusCivis ostiumCarrusCivis,
            HorologiaCivisStatuumCustodiaeMutationis horologiaCivisStatuumCustodiaeMutationis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivis, ostiumTemporisLegibile) {
            _horologiaCivisStatuumCustodiaeMutationis = horologiaCivisStatuumCustodiaeMutationis;
        }

        public override void Intrare(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.ActivareVigilantiam(idCivis);
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareVigilantiam(idCivis);
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // horologium時間が経過した時
            if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaVigilantiam(idCivis, Temporis.Intervallum)) {
                return IDCivisStatusCustodiae.Spectans;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}