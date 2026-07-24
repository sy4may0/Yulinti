namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisVeletudinisMaxima {
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IResolutorCivisVitaeMaxima _resolutorCivisVitaeMaxima;
        private readonly IResolutorCivisVisusMaxima _resolutorCivisVisusMaxima;
        private readonly IResolutorCivisAuditusMaxima _resolutorCivisAuditusMaxima;
        private readonly IResolutorCivisSuspectaMaxima _resolutorCivisSuspectaMaxima;
        private readonly IResolutorCivisStudiumMaxima _resolutorCivisStudiumMaxima;
        private readonly IResolutorCivisIntentioMaxima _resolutorCivisIntentioMaxima;
        private readonly IResolutorCivisTorelantiaAnomaliaeMaximaMaxima _resolutorCivisTorelantiaAnomaliaeMaximaMaxima;
        private readonly IResolutorCivisTorelantiaAnomaliaeMinimaMaxima _resolutorCivisTorelantiaAnomaliaeMinimaMaxima;

        private float _vitaeMaxima;
        private float _visusMaxima;
        private float _auditusMaxima;
        private float _suspectaMaxima;
        private float _studiumMaxima;
        private float _intentioMaxima;

        public MilesCivisVeletudinisMaxima(
            IOstiumCarrusCivis carrus,
            IResolutorCivisVitaeMaxima resolutorCivisVitaeMaxima,
            IResolutorCivisVisusMaxima resolutorCivisVisusMaxima,
            IResolutorCivisAuditusMaxima resolutorCivisAuditusMaxima,
            IResolutorCivisSuspectaMaxima resolutorCivisSuspectaMaxima,
            IResolutorCivisStudiumMaxima resolutorCivisStudiumMaxima,
            IResolutorCivisIntentioMaxima resolutorCivisIntentioMaxima,
            IResolutorCivisTorelantiaAnomaliaeMaximaMaxima resolutorCivisTorelantiaAnomaliaeMaximaMaxima,
            IResolutorCivisTorelantiaAnomaliaeMinimaMaxima resolutorCivisTorelantiaAnomaliaeMinimaMaxima
        ) {
            _carrus = carrus;
            _resolutorCivisVitaeMaxima = resolutorCivisVitaeMaxima;
            _resolutorCivisVisusMaxima = resolutorCivisVisusMaxima;
            _resolutorCivisAuditusMaxima = resolutorCivisAuditusMaxima;
            _resolutorCivisSuspectaMaxima = resolutorCivisSuspectaMaxima;
            _resolutorCivisStudiumMaxima = resolutorCivisStudiumMaxima;
            _resolutorCivisIntentioMaxima = resolutorCivisIntentioMaxima;
            _resolutorCivisTorelantiaAnomaliaeMaximaMaxima = resolutorCivisTorelantiaAnomaliaeMaximaMaxima;
            _resolutorCivisTorelantiaAnomaliaeMinimaMaxima = resolutorCivisTorelantiaAnomaliaeMinimaMaxima;
        }

        public void Initare(int idCivis) {
            // 計算を減らすため初期化時にキャッシュする。
            // TorelantiaはPuellaeのAnomaliaMaximaに追従するため毎フレームResolvereする。
            _vitaeMaxima = _resolutorCivisVitaeMaxima.Resolvere();
            _visusMaxima = _resolutorCivisVisusMaxima.Resolvere();
            _auditusMaxima = _resolutorCivisAuditusMaxima.Resolvere();
            _suspectaMaxima = _resolutorCivisSuspectaMaxima.Resolvere();
            _studiumMaxima = _resolutorCivisStudiumMaxima.Resolvere();
            _intentioMaxima = _resolutorCivisIntentioMaxima.Resolvere();
            Ordinare(idCivis);
        }

        public void Ordinare(int idCivis) {
            _carrus.PostulareVeletudinisMaxima(
                idCivis,
                dtVitaeMaxima: _vitaeMaxima,
                dtVisusMaxima: _visusMaxima,
                dtAuditusMaxima: _auditusMaxima,
                dtSuspectaMaxima: _suspectaMaxima,
                dtStudiumMaxima: _studiumMaxima,
                dtIntentioMaxima: _intentioMaxima,
                dtTorelantiaAnomaliaeMaximaMaxima: _resolutorCivisTorelantiaAnomaliaeMaximaMaxima.Resolvere(),
                dtTorelantiaAnomaliaeMinimaMaxima: _resolutorCivisTorelantiaAnomaliaeMinimaMaxima.Resolvere()
            );
        }
    }
}
