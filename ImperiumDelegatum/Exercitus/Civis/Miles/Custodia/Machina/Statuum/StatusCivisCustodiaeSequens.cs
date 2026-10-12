using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeSequens : StatusBasisCivisCustodiaePersecutio {

        private readonly HorologiaCivisStatuumCustodiaeMutationis _horologiaCivisStatuumCustodiaeMutationis;

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Sequens;

        public StatusCivisCustodiaeSequens(
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
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensIntentioZero(idCivis);
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensIntentioZero(idCivis);
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

            // Intentio = 0% -> Refrigeratio
            if (ResFluidaCivisVeletudinis.RatioIntentionis(idCivis) <= Numerus.Epsilon) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSequensIntentioZero(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSequensIntentioZero(idCivis);
                }
                // Exhaurita -> Refrigeratio
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSequensIntentioZero(idCivis, Temporis.Intervallum)) {
                    _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensIntentioZero(idCivis);
                    return IDCivisStatusCustodiae.Refrigeratio;
                }
            } else {
                // Intentio > 0% horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensIntentioZero(idCivis);
            }

            // 視認ロスト -> Quaerens
            if (!ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSequensInVisus(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSequensInVisus(idCivis);
                }
                // Exhaurita -> Quaerens
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSequensInVisus(idCivis, Temporis.Intervallum)) {
                    _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensInVisus(idCivis);
                    return IDCivisStatusCustodiae.Quaerens;
                }
            } else {
                // 視認中 horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivateSequensInVisus(idCivis);
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
