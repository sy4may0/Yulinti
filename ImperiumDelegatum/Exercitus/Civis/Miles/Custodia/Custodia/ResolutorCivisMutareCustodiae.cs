using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisMutareCustodiae {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumCivisLegibile _civis;

        private readonly bool[] _estSpectareNudusPrioris;

        public ResolutorCivisMutareCustodiae(
            IConfiguratioCivisCustodiae configuratioCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumCivisLegibile civis
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _carrus = carrus;
            _civis = civis;
            _estSpectareNudusPrioris = new bool[_civis.Longitudo];
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

                _carrus.PostulareVeletudinisValoris(
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
                    _carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtSuspecta: 1f
                    );
                } else {
                    _carrus.PostulareVeletudinisValoris(
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
            float limenVigilantia = _configuratioCivisCustodiae.LimenVigilantia;
            float limenDetectio = _configuratioCivisCustodiae.LimenDetectio;
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

            _carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estVigilantia: vigilantiaProximus,
                estDetectio: detectioProximus
            );
        }

        public void ResolvereDetectioSonora(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            bool detectioSonoraProximus = resFluida.Veletudinis.EstDetectioSonora(idCivis);
            float limenDetectioSonora = _configuratioCivisCustodiae.LimenDetectioSonora;
            float hysteriaDetectioSonora = ConstansCivis.HysteriaDetectioSonora;

            if (resFluida.Veletudinis.Audita(idCivis) > limenDetectioSonora + hysteriaDetectioSonora) {
                detectioSonoraProximus = true;
            } else if (resFluida.Veletudinis.Audita(idCivis) < limenDetectioSonora - hysteriaDetectioSonora) {
                detectioSonoraProximus = false;
            } 
            
            if (detectioSonoraProximus == resFluida.Veletudinis.EstDetectioSonora(idCivis)) return;

            _carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estDetectioSonora: detectioSonoraProximus
            );
        }

        public void ResolvereSuspecta(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            bool suspectaProximus = resFluida.Veletudinis.EstSuspecta(idCivis);
            float limenSuspecta = _configuratioCivisCustodiae.LimenSuspecta;
            float hysteriaSuspecta = ConstansCivis.HysteriaSuspecta;

            if (resFluida.Veletudinis.Suspecta(idCivis) > limenSuspecta + hysteriaSuspecta) {
                suspectaProximus = true;
            } else if (resFluida.Veletudinis.Suspecta(idCivis) < limenSuspecta - hysteriaSuspecta) {
                suspectaProximus = false;
            }

            if (suspectaProximus == resFluida.Veletudinis.EstSuspecta(idCivis)) return;

            _carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estSuspecta: suspectaProximus
            );
        }
    }
}