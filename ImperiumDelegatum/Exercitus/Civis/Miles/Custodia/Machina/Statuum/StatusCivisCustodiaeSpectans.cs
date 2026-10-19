using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeSpectans : StatusBasisCivisCustodiaePersecutio {

        private readonly HorologiaCivisStatuumCustodiaeMutationis _horologiaCivisStatuumCustodiaeMutationis;

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Spectans;

        public StatusCivisCustodiaeSpectans(
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
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSpectantemInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSpectantemIntentionisZero(idCivis);

            CarrusVeletudinis.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Spectans
            );
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSpectantemInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSpectantemIntentionisZero(idCivis);
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // Anomalia超過を視認 -> Discedens
            if (EstExcessusAnomaliaeVisae(idCivis)) {
                return IDCivisStatusCustodiae.Discedens;
            }

            // Intentio > 50% -> Sequens
            if (ResFluidaCivisVeletudinis.RatioIntentionis(idCivis) > 0.5f) {
                return IDCivisStatusCustodiae.Sequens;
            }

            // Intentio = 0% -> Refrigeratio
            if (ResFluidaCivisVeletudinis.RatioIntentionis(idCivis) <= Numerus.Epsilon) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSpectantisIntentionisZero(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSpectantemIntentionisZero(idCivis);
                }
                // Exhaurita -> Refrigeratio
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSpectantisIntentionisZero(idCivis, Temporis.Intervallum)) {
                    return IDCivisStatusCustodiae.Refrigeratio;
                }
            } else {
                // Intentio > 0% horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivareSpectantemIntentionisZero(idCivis);
            }

            // 視認ロスト -> Quaerens
            if (!ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSpectantisInVisus(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSpectantemInVisus(idCivis);
                }
                // Exhaurita -> Quaerens
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSpectantisInVisus(idCivis, Temporis.Intervallum)) {
                    return IDCivisStatusCustodiae.Quaerens;
                }
            } else {
                // 視認中 horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivareSpectantemInVisus(idCivis);
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
