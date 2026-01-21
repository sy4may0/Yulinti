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
                // suspecta < RatioSuspectaVisaの場合、visa = suspecta。
                // suspecta >= RatioSuspectaVisaの場合、visa = RatioSuspectaVisa。
                // 最大RatioSuspectaVisaまでで、visaをsuspectaに合わせる。
                float visa = resFluida.Veletudinis.Visa(idCivis);
                float suspecta = resFluida.Veletudinis.Suspecta(idCivis);
                float dtVisa = 0f;

                if (suspecta < ConstansCivis.RatioSuspectaVisa) {
                    dtVisa = suspecta - visa;
                } else {
                    dtVisa = (ConstansCivis.RatioSuspectaVisa - visa);
                }

                _contextus.Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtVisa: dtVisa
                );
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
            float hysteriaDetectionis = ConstansCivis.HysteriaDetectionis;

            // 通常時変動
            if (!resFluida.Veletudinis.EstVigilantia(idCivis) && !resFluida.Veletudinis.EstDetectio(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) > limenVigilantia + hysteriaDetectionis) {
                    // 通常 -> 警戒
                    vigilantiaProximus = true;
                    detectioProximus = false;
                }
            }
            // 警戒時変動
            if (resFluida.Veletudinis.EstVigilantia(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) > limenDetectio + hysteriaDetectionis) {
                    // 警戒 -> 検知
                    vigilantiaProximus = false;
                    detectioProximus = true;
                } else if (resFluida.Veletudinis.Visa(idCivis) < limenVigilantia - hysteriaDetectionis) {
                    // 警戒 -> 通常
                    vigilantiaProximus = false;
                    detectioProximus = false;
                }
            }
            // 検知時変動
            if (resFluida.Veletudinis.EstDetectio(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) < limenDetectio - hysteriaDetectionis) {
                    // 検知 -> 警戒
                    vigilantiaProximus = true;
                    detectioProximus = false;
                }
            }

            if (
                 vigilantiaProximus == resFluida.Veletudinis.EstVigilantia(idCivis) &&
                 detectioProximus == resFluida.Veletudinis.EstDetectio(idCivis)
            ) return;

            _contextus.Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estVigilantia: vigilantiaProximus,
                estDetectio: detectioProximus
            );
        }

        public void ResolvereAudivi(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            bool audiviProximus = resFluida.Veletudinis.EstAudivi(idCivis);
            float limenAudivi = _contextus.Configuratio.Custodiae.LimenAudivi;
            float hysteriaAudivi = ConstansCivis.HysteriaAudivi;

            if (resFluida.Veletudinis.Audita(idCivis) > limenAudivi + hysteriaAudivi) {
                audiviProximus = true;
            } else if (resFluida.Veletudinis.Audita(idCivis) < limenAudivi - hysteriaAudivi) {
                audiviProximus = false;
            } 
            
            if (audiviProximus == resFluida.Veletudinis.EstAudivi(idCivis)) return;

            _contextus.Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estAudivi: audiviProximus
            );
        }

        public void ResolvereSuspecta(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            bool suspectaProximus = resFluida.Veletudinis.EstSuspecta(idCivis);
            float limenSuspecta = _contextus.Configuratio.Custodiae.LimenSuspecta;
            float hysteriaSuspecta = ConstansCivis.HysteriaSuspecta;

            if (resFluida.Veletudinis.Suspecta(idCivis) > limenSuspecta + hysteriaSuspecta) {
                suspectaProximus = true;
            } else if (resFluida.Veletudinis.Suspecta(idCivis) < limenSuspecta - hysteriaSuspecta) {
                suspectaProximus = false;
            }

            if (suspectaProximus == resFluida.Veletudinis.EstSuspecta(idCivis)) return;

            _contextus.Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estSuspecta: suspectaProximus
            );
        }
    }
}