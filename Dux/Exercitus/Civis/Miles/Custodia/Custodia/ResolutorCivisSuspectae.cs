using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal enum CustodiaCivisSuspectaeModi {
        Ictuum,
        Consumptio
    }

    internal sealed class ResolutorCivisSuspectae {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly IResolutorCivisIctuumVisae _resolutorCivisIctuum;

        private readonly CustodiaCivisSuspectaeModi[] _modiActualis;
        private readonly AbacusStudiumAmittere[] _abacusStudiumAmittere;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        public ResolutorCivisSuspectae(
            ContextusCivisOstiorumLegibile contextus,
            IResolutorCivisIctuumVisae resolutorCivisIctuum,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _contextus = contextus;
            _resolutorCivisIctuum = resolutorCivisIctuum;
            _resolutorCivisDistantia = resolutorCivisDistantia;

            _modiActualis = new CustodiaCivisSuspectaeModi[_contextus.Civis.Longitudo];
            _abacusStudiumAmittere = new AbacusStudiumAmittere[_contextus.Civis.Longitudo];
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                _modiActualis[i] = CustodiaCivisSuspectaeModi.Consumptio;
                _abacusStudiumAmittere[i] = new AbacusStudiumAmittere(
                    contextus,
                    _contextus.Configuratio.Custodiae.TempusStudiumAmittereSec,
                    _contextus.Configuratio.Custodiae.TempusStudiumAmittereMaximaSec,
                    _contextus.Configuratio.Custodiae.PraeruptioTempusAmittere
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
            _abacusStudiumAmittere[idCivis].Pulsus();
            float ratio = _abacusStudiumAmittere[idCivis].ComputareRatio();
            float dtSuspecta = _contextus.Configuratio.Custodiae.ConsumptioSuspectaSec * ratio * _contextus.Temporis.Intervallum;
            _contextus.Carrus.PostulareVeletudinisValoris(
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
            dtSuspecta *= _contextus.Configuratio.Custodiae.RatioSuspecta; // 設定による上昇補正値
            dtSuspecta *= _contextus.ResFPuellae.Veletudinis.Claritas; // PuellaeステートのClaritas補正を適用する。
            dtSuspecta *= _contextus.Temporis.Intervallum; // フレーム時間を適用する。
            _contextus.Carrus.PostulareVeletudinisValoris(
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