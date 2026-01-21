using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisMutareCustodiae {
        private readonly ContextusCivisOstiorumLegibile _contextus;

        private readonly bool[] _estSpectareNudusPrioris;

        public ResolutorCivisMutareCustodiae(ContextusCivisOstiorumLegibile contextus) {
            _contextus = contextus;
            _estSpectareNudusPrioris = new bool[contextus.Civis.Longitudo];
        }

        public void Initare(int idCivis) {
            _estSpectareNudusPrioris[idCivis] = false;
        }

        private void ResolvereSuspectaVisa(int idCivis, IResFluidaCivisLegibile resFluida) {
            if (_estSpectareNudusPrioris[idCivis] == resFluida.Veletudinis.EstSpectareNudus(idCivis)) return;
            bool _estSpectare = resFluida.Veletudinis.EstSpectareNudus(idCivis);

            if (_estSpectare) {
                // 非Nudus視認 -> Nudus視認
                float visa = resFluida.Veletudinis.Visa(idCivis);
                float suspecta = resFluida.Veletudinis.Suspecta(idCivis);
                float dtVisa = (suspecta * ConstansCivis.RatioSuspectaVisa - visa); // 一括で上げる。Temporisで割らない。 
                if (dtVisa > 0f) {
                    _contextus.Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtVisa: dtVisa
                    );
                }
            }
            else {
                // Nudus視認 -> 非Nudus視認
                // Visilantia, Detectio時はSuspectaを1とする。
                // それ以外はSuspectaをVisaに合わせる。
                float visa = resFluida.Veletudinis.Visa(idCivis);
                float suspecta = resFluida.Veletudinis.Suspecta(idCivis);
                if (resFluida.Veletudinis.EstVigilantia(idCivis) || resFluida.Veletudinis.EstDetectio(idCivis)) {
                    _contextus.Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtSuspecta: 1f
                    );
                } else {
                    _contextus.Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtSuspecta: visa - suspecta
                    );
                }
            }

            _estSpectareNudusPrioris[idCivis] = _estSpectare;
        }

        public void OrdinareVisa(int idCivis, IResFluidaCivisLegibile resFluida) {
            ResolvereSuspectaVisa(idCivis, resFluida);
        }

        public void ResolvereDetectio(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            bool vigilantiaProximus = resFluida.Veletudinis.EstVigilantia(idCivis);
            bool detectioProximus = resFluida.Veletudinis.EstDetectio(idCivis);
            float limenVigilantia = _contextus.Configuratio.Custodiae.LimenVigilantia;
            float limenDetectio = _contextus.Configuratio.Custodiae.LimenDetectio;
            float hysteresisDetectionis = ConstansCivis.HysteriaDetectionis;

            // 通常時変動
            if (!resFluida.Veletudinis.EstVigilantia(idCivis) && !resFluida.Veletudinis.EstDetectio(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) > limenVigilantia + hysteresisDetectionis) {
                    // 通常 -> 警戒
                    vigilantiaProximus = true;
                    detectioProximus = false;
                }
            }
            // 警戒時変動
            if (resFluida.Veletudinis.EstVigilantia(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) > limenDetectio + hysteresisDetectionis) {
                    // 警戒 -> 検知
                    vigilantiaProximus = false;
                    detectioProximus = true;
                } else if (resFluida.Veletudinis.Visa(idCivis) < limenVigilantia - hysteresisDetectionis) {
                    // 警戒 -> 通常
                    vigilantiaProximus = false;
                    detectioProximus = false;
                }
            }
            // 検知時変動
            if (resFluida.Veletudinis.EstDetectio(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) < limenDetectio - hysteresisDetectionis) {
                    // 検知 -> 警戒
                    vigilantiaProximus = true;
                    detectioProximus = false;
                }
            }

            _contextus.Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estVigilantia: vigilantiaProximus,
                estDetectio: detectioProximus
            );
        }
    }
}