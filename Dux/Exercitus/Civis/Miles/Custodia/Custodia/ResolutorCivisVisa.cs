using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal enum CustodiaCivisVisaeModi {
        Ictuum,
        ConsumptioDetectio,
        Consumptio
    }

    internal sealed class ResolutorCivisVisa {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly IResolutorCivisIctuumVisae _resolutorCivisIctuum;

        private readonly CustodiaCivisVisaeModi[] _modiActualis;
        private readonly AbacusStudiumAmittere[] _abacusStudiumAmittere;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        public ResolutorCivisVisa(
            ContextusCivisOstiorumLegibile contextus,
            IResolutorCivisIctuumVisae resolutorCivisIctuum,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _contextus = contextus;
            _resolutorCivisIctuum = resolutorCivisIctuum;
            _resolutorCivisDistantia = resolutorCivisDistantia;

            _modiActualis = new CustodiaCivisVisaeModi[_contextus.Civis.Longitudo];
            _abacusStudiumAmittere = new AbacusStudiumAmittere[_contextus.Civis.Longitudo];
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                _modiActualis[i] = CustodiaCivisVisaeModi.Consumptio;
                _abacusStudiumAmittere[i] = new AbacusStudiumAmittere(
                    _contextus.Configuratio.Custodiae.TempusStudiumAmittereSec,
                    _contextus.Configuratio.Custodiae.TempusStudiumAmittereMaximaSec,
                    _contextus.Configuratio.Custodiae.PraeruptioTempusAmittere
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
            float dtVisa = _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * _contextus.Temporis.Intervallum;
            _contextus.Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisa: dtVisa
            );
        }

        private void Consumptio(
            int idCivis
        ) {
            _abacusStudiumAmittere[idCivis].Pulsus(_contextus.Temporis.Intervallum);
            float ratio = _abacusStudiumAmittere[idCivis].ComputareRatio();
            float dtVisa = _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * ratio * _contextus.Temporis.Intervallum;
            _contextus.Carrus.PostulareVeletudinisValoris(
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
            dtVisa *= _contextus.Configuratio.Custodiae.RatioVisus; // 設定による上昇補正値
            dtVisa *= _contextus.ResFPuellae.Veletudinis.Claritas; // PuellaeステートのClaritas補正を適用する。
            dtVisa *= _contextus.Temporis.Intervallum; // フレーム時間を適用する。
            _contextus.Carrus.PostulareVeletudinisValoris(
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