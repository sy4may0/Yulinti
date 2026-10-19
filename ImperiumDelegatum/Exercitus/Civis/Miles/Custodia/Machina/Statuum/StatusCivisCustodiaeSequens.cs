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
            IOstiumCarrusCivisVeletudinis ostiumCarrusCivisVeletudinis,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            HorologiaCivisStatuumCustodiaeMutationis horologiaCivisStatuumCustodiaeMutationis
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile) {
            _horologiaCivisStatuumCustodiaeMutationis = horologiaCivisStatuumCustodiaeMutationis;
        }

        public override void Intrare(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSequentemInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSequentemIntentionisZero(idCivis);

            CarrusVeletudinis.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Sequens
            );
        }

        public override void Exire(int idCivis) {
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSequentemInVisus(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.DeactivareSequentemIntentionisZero(idCivis);
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // Anomalia超過を視認 -> Discedens
            if (EstExcessusAnomaliaeVisae(idCivis)) {
                return IDCivisStatusCustodiae.Discedens;
            }

            // Intentio = 0% -> Refrigeratio
            if (ResFluidaCivisVeletudinis.RatioIntentionis(idCivis) <= Numerus.Epsilon) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSequentisIntentionisZero(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSequentemIntentionisZero(idCivis);
                }
                // Exhaurita -> Refrigeratio
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSequentisIntentionisZero(idCivis, Temporis.Intervallum)) {
                    return IDCivisStatusCustodiae.Refrigeratio;
                }
            } else {
                // Intentio > 0% horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivareSequentemIntentionisZero(idCivis);
            }

            // 視認ロスト -> Quaerens
            if (!ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                // 初回Activare
                if (!_horologiaCivisStatuumCustodiaeMutationis.EstActivumSequentisInVisus(idCivis)) {
                    _horologiaCivisStatuumCustodiaeMutationis.ActivareSequentemInVisus(idCivis);
                }
                // Exhaurita -> Quaerens
                if (_horologiaCivisStatuumCustodiaeMutationis.EstExhauritaSequentisInVisus(idCivis, Temporis.Intervallum)) {
                    return IDCivisStatusCustodiae.Quaerens;
                }
            } else {
                // 視認中 horologium停止
                _horologiaCivisStatuumCustodiaeMutationis.DeactivareSequentemInVisus(idCivis);
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
