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
            IOstiumCarrusCivis ostiumCarrusCivis,
            HorologiaCivisStatuumCustodiaeMutationis horologiaCivisStatuumCustodiaeMutationis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivis, ostiumTemporisLegibile) {
            _horologiaCivisStatuumCustodiaeMutationis = horologiaCivisStatuumCustodiaeMutationis;
        }

        public override void Intrare(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansIntentioZero(idCivis);
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansIntentioZero(idCivis);
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // Anomalia超過時 -> Discedens
            float anomaliaPuellae = ResFluidaPuellaeVeletudinis.Anomalia;
            if (ResFluidaCivisVeletudinis.EstSpectareNudus(idCivis)) {
                anomaliaPuellae = ResFluidaPuellaeVeletudinis.AnomaliaNudus;
            }
            if (anomaliaPuellae > ResFluidaCivisVeletudinis.TorelantiaAnomaliaeMaxima(idCivis)) {
                return IDCivisStatusCustodiae.Discedens;
            }

            // Intentio > 50% -> Sequens
            if (ResFluidaCivisVeletudinis.RatioIntentionis(idCivis) > 0.5f) {
                return IDCivisStatusCustodiae.Sequens;
            }

            // Intentio = 0% -> Refrigeratio
            if (ResFluidaCivisVeletudinis.RatioIntentionis(idCivis) <= Numerus.Epsilon) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSpectansIntentioZero(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSpectansIntentioZero(idCivis);
                }
                // Exhaurita -> Refrigeratio
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSpectansIntentioZero(idCivis, Temporis.Intervallum)) {
                    _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansIntentioZero(idCivis);
                    return IDCivisStatusCustodiae.Refrigeratio;
                }
            } else {
                // Intentio > 0% horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansIntentioZero(idCivis);
            }

            // 視認ロスト -> Quaerens
            if (!ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSpectansInVisus(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSpectansInVisus(idCivis);
                }
                // Exhaurita -> Quaerens
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSpectansInVisus(idCivis, Temporis.Intervallum)) {
                    _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansInVisus(idCivis);
                    return IDCivisStatusCustodiae.Quaerens;
                }
            } else {
                // 視認中 horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivateSpectansInVisus(idCivis);
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}