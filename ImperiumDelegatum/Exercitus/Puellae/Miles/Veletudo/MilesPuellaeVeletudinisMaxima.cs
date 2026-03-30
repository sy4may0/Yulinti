using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeVeletudinisMaxima {
        private readonly IOstiumCarrusPuellae _carrus;
        private readonly IResolutorPuellaeVigorisMaxima _resolutorPuellaeVigorisMaxima;
        private readonly IResolutorPuellaePatientiaeMaxima _resolutorPuellaePatientiaeMaxima;
        private readonly IResolutorPuellaeClaritatisMaximus _resolutorPuellaeClaritatisMaximus;
        private readonly IResolutorPuellaeAetherisMaxima _resolutorPuellaeAetherisMaxima;
        private readonly IResolutorPuellaeIntentioMaxima _resolutorPuellaeIntentioMaxima;
        private readonly IResolutorPuellaeDedecorisMaximum _resolutorPuellaeDedecorisMaximum;
        private readonly IResolutorPuellaeSonusQuietesMaximus _resolutorPuellaeSonusQuietesMaximus;
        private readonly IResolutorPuellaeSonusMotusMaximus _resolutorPuellaeSonusMotusMaximus;

        private float _vigorMaxima;
        private float _patientiaeMaxima;
        private float _claritasMaxima;
        private float _aetherMaxima;
        private float _intentioMaxima;
        private float _dedecusMaxima;
        private float _sonusQuietesMaxima;
        private float _sonusMotusMaxima;

        public MilesPuellaeVeletudinisMaxima(
            IOstiumCarrusPuellae carrus,
            IResolutorPuellaeVigorisMaxima resolutorPuellaeVigorisMaxima,
            IResolutorPuellaePatientiaeMaxima resolutorPuellaePatientiaeMaxima,
            IResolutorPuellaeClaritatisMaximus resolutorPuellaeClaritatisMaximus,
            IResolutorPuellaeAetherisMaxima resolutorPuellaeAetherisMaxima,
            IResolutorPuellaeIntentioMaxima resolutorPuellaeIntentioMaxima,
            IResolutorPuellaeDedecorisMaximum resolutorPuellaeDedecorisMaximum,
            IResolutorPuellaeSonusQuietesMaximus resolutorPuellaeSonusQuietesMaximus,
            IResolutorPuellaeSonusMotusMaximus resolutorPuellaeSonusMotusMaximus) 
        {
            _carrus = carrus;
            _resolutorPuellaeVigorisMaxima = resolutorPuellaeVigorisMaxima;
            _resolutorPuellaePatientiaeMaxima = resolutorPuellaePatientiaeMaxima;
            _resolutorPuellaeClaritatisMaximus = resolutorPuellaeClaritatisMaximus;
            _resolutorPuellaeAetherisMaxima = resolutorPuellaeAetherisMaxima;
            _resolutorPuellaeIntentioMaxima = resolutorPuellaeIntentioMaxima;
            _resolutorPuellaeDedecorisMaximum = resolutorPuellaeDedecorisMaximum;
            _resolutorPuellaeSonusQuietesMaximus = resolutorPuellaeSonusQuietesMaximus;
            _resolutorPuellaeSonusMotusMaximus = resolutorPuellaeSonusMotusMaximus;
        }

        public void Initare() {
            // 計算を減らすため初期化時にキャッシュする。
            _vigorMaxima = _resolutorPuellaeVigorisMaxima.Resolvere();
            _patientiaeMaxima = _resolutorPuellaePatientiaeMaxima.Resolvere();
            _claritasMaxima = _resolutorPuellaeClaritatisMaximus.Resolvere();
            _aetherMaxima = _resolutorPuellaeAetherisMaxima.Resolvere();
            _intentioMaxima = _resolutorPuellaeIntentioMaxima.Resolvere();
            _dedecusMaxima = _resolutorPuellaeDedecorisMaximum.Resolvere();
            _sonusQuietesMaxima = _resolutorPuellaeSonusQuietesMaximus.Resolvere();
            _sonusMotusMaxima = _resolutorPuellaeSonusMotusMaximus.Resolvere();
            Ordinare();
        }

        public void Ordinare() {
            _carrus.PostulareVeletudinisMaxima(
                dtVigorMaxima: _vigorMaxima,
                dtPatientiaeMaxima: _patientiaeMaxima,
                dtAetherMaxima: _aetherMaxima,
                dtClaritasMaxima: _claritasMaxima,
                dtIntentioMaxima: _intentioMaxima,
                dtDedecusMaxima: _dedecusMaxima,
                dtSonusQuietesMaxima: _sonusQuietesMaxima,
                dtSonusMotusMaxima: _sonusMotusMaxima
            );
        }
    }
}