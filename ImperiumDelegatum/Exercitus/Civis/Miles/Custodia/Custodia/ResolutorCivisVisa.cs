using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum CustodiaCivisVisaeModi {
        Ictuum,
        ConsumptioDetectio,
        Consumptio
    }

    internal sealed class ResolutorCivisVisa {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IResFluidaPuellaeLegibile _resFPuellae;

        private readonly IResolutorCivisIctuumVisae _resolutorCivisIctuum;

        private readonly CustodiaCivisVisaeModi[] _modiActualis;
        private readonly AbacusTemporis[] _abacusStudiumAmittere;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        public ResolutorCivisVisa(
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

            _modiActualis = new CustodiaCivisVisaeModi[_civis.Longitudo];
            _abacusStudiumAmittere = new AbacusTemporis[_civis.Longitudo];
            for (int i = 0; i < _civis.Longitudo; i++) {
                _modiActualis[i] = CustodiaCivisVisaeModi.Consumptio;
                _abacusStudiumAmittere[i] = new AbacusTemporis(
                    _configuratioCivisCustodiae.TempusStudiumAmittereMaximaSec,
                    0f,
                    _configuratioCivisCustodiae.TempusStudiumAmittereSec,
                    _configuratioCivisCustodiae.PraeruptioTempusAmittere
                );
            }
        }

        public void Initare(int idCivis) {
            _modiActualis[idCivis] = CustodiaCivisVisaeModi.Consumptio;
            _abacusStudiumAmittere[idCivis].Purgere();
        }

        private void ResolvereModi(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // 別ResolutorでSpectareNudusを解決しておくこと。
            if (
                _resolutorCivisIctuum.EstVisa(idCivis) && // 視認数がある。
                resFluida.Veletudinis.EstSpectareNudus(idCivis) && // かつSpectareNudusである。
                _resolutorCivisDistantia.EstCustodiaeVisae(idCivis) // かつ視認範囲内にいる。
            ) {
                _modiActualis[idCivis] = CustodiaCivisVisaeModi.Ictuum;
            } else if (resFluida.Veletudinis.EstDetectio(idCivis)) {
                _modiActualis[idCivis] = CustodiaCivisVisaeModi.ConsumptioDetectio;
            } else {
                _modiActualis[idCivis] = CustodiaCivisVisaeModi.Consumptio;
            }
        }

        private void ConsumptioDetectio(
            int idCivis
        ) {
            _abacusStudiumAmittere[idCivis].Purgere();
            float dtVisa = _configuratioCivisCustodiae.ConsumptioVisaeSec * _temporis.Intervallum;
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisa: dtVisa
            );
        }

        private void Consumptio(
            int idCivis
        ) {
            _abacusStudiumAmittere[idCivis].Pulsus(_temporis.Intervallum);
            float ratio = _abacusStudiumAmittere[idCivis].ComputareRatio();
            float dtVisa = _configuratioCivisCustodiae.ConsumptioVisaeSec * ratio * _temporis.Intervallum;
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisa: dtVisa
            );
        }

        private void Ictuum(
            int idCivis
        ) {
            _abacusStudiumAmittere[idCivis].Purgere();
            float dtVisa = _resolutorCivisIctuum.VisaCapitis(idCivis) + _resolutorCivisIctuum.VisaCorporis(idCivis);
            dtVisa /= 100f; // dtVisaは0~1の比率なので100で割る。
            dtVisa *= _configuratioCivisCustodiae.RatioVisus; // 設定による上昇補正値
            dtVisa *= _resFPuellae.Veletudinis.Claritas; // PuellaeステートのClaritas補正を適用する。
            dtVisa *= _temporis.Intervallum; // フレーム時間を適用する。
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisa: dtVisa
            );
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            ResolvereModi(idCivis, resFluida);
            switch (_modiActualis[idCivis]) {
                case CustodiaCivisVisaeModi.Ictuum:
                    if (resFluida.Veletudinis.Visa(idCivis) >= 1f - Numerus.Epsilon) break;
                    Ictuum(idCivis);
                    break;
                case CustodiaCivisVisaeModi.ConsumptioDetectio:
                    if (resFluida.Veletudinis.Visa(idCivis) <= Numerus.Epsilon) break;
                    ConsumptioDetectio(idCivis);
                    break;
                case CustodiaCivisVisaeModi.Consumptio:
                    if (resFluida.Veletudinis.Visa(idCivis) <= Numerus.Epsilon) break;
                    Consumptio(idCivis);
                    break;
            }
        }
    }
}