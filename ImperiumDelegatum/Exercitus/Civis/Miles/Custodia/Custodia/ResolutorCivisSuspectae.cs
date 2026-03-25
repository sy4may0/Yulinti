using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum CustodiaCivisSuspectaeModi {
        Ictuum,
        Consumptio
    }

    internal sealed class ResolutorCivisSuspectae {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IResFluidaPuellaeLegibile _resFPuellae;

        private readonly IResolutorCivisIctuumVisae _resolutorCivisIctuum;

        private readonly CustodiaCivisSuspectaeModi[] _modiActualis;
        private readonly AbacusTemporis[] _abacusStudiumAmittere;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        public ResolutorCivisSuspectae(
            IConfiguratioCivisCustodiae configuratioCivisCustodiae,
            IOstiumTemporisLegibile temporis,
            IOstiumCivisLegibile civis,
            IOstiumCarrusCivis carrus,
            IResFluidaPuellaeLegibile resFPuellae,
            IResolutorCivisIctuumVisae resolutorCivisIctuum,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _temporis = temporis;
            _civis = civis;
            _carrus = carrus;
            _resFPuellae = resFPuellae;
            _resolutorCivisIctuum = resolutorCivisIctuum;
            _resolutorCivisDistantia = resolutorCivisDistantia;

            _modiActualis = new CustodiaCivisSuspectaeModi[_civis.Longitudo];
            _abacusStudiumAmittere = new AbacusTemporis[_civis.Longitudo];
            for (int i = 0; i < _civis.Longitudo; i++) {
                _modiActualis[i] = CustodiaCivisSuspectaeModi.Consumptio;
                _abacusStudiumAmittere[i] = new AbacusTemporis(
                    _configuratioCivisCustodiae.TempusStudiumAmittereMaximaSec,
                    0f,
                    _configuratioCivisCustodiae.TempusStudiumAmittereSec,
                    _configuratioCivisCustodiae.PraeruptioTempusAmittere
                );
            }
        }

        public void Initare(int idCivis) {
            _modiActualis[idCivis] = CustodiaCivisSuspectaeModi.Consumptio;
            _abacusStudiumAmittere[idCivis].Purgere();
        }

        private void ResolvereModi(
            int idCivis,
            IResFluidaCivisLegibile resFluida
         ) {
            if (
                _resolutorCivisIctuum.EstVisa(idCivis) && // 視認数がある。
                _resolutorCivisDistantia.EstCustodiaeVisae(idCivis) // かつ視認範囲内にいる。
            ) {
                _modiActualis[idCivis] = CustodiaCivisSuspectaeModi.Ictuum;
            } else {
                _modiActualis[idCivis] = CustodiaCivisSuspectaeModi.Consumptio;
            }
        }

        private void Consumptio(
            int idCivis
        ) {
            _abacusStudiumAmittere[idCivis].Pulsus(_temporis.Intervallum);
            float ratio = _abacusStudiumAmittere[idCivis].ComputareRatio();
            float dtSuspecta = _configuratioCivisCustodiae.ConsumptioSuspectaSec * ratio * _temporis.Intervallum;
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: dtSuspecta
            );
        }

        private void Ictuum(
            int idCivis
        ) {
            _abacusStudiumAmittere[idCivis].Purgere();
            float dtSuspecta = _resolutorCivisIctuum.VisaCapitis(idCivis) + _resolutorCivisIctuum.VisaCorporis(idCivis);
            dtSuspecta /= 100f; // dtSuspectaは0~1の比率なので100で割る。
            dtSuspecta *= _configuratioCivisCustodiae.RatioSuspecta; // 設定による上昇補正値
            dtSuspecta *= _resFPuellae.Veletudinis.Claritas; // PuellaeステートのClaritas補正を適用する。
            dtSuspecta *= _temporis.Intervallum; // フレーム時間を適用する。
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: dtSuspecta
            );
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            ResolvereModi(idCivis, resFluida);
            switch (_modiActualis[idCivis]) {
                case CustodiaCivisSuspectaeModi.Ictuum:
                    if (resFluida.Veletudinis.Suspecta(idCivis) >= 1f - Numerus.Epsilon) break;
                    Ictuum(idCivis);
                    break;
                case CustodiaCivisSuspectaeModi.Consumptio:
                    if (resFluida.Veletudinis.Suspecta(idCivis) <= Numerus.Epsilon) break;
                    Consumptio(idCivis);
                    break;
            }
        }
    }
}