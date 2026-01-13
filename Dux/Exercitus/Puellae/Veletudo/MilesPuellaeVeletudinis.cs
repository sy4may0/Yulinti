namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeVeletudinis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        // 加算変動値
        // 初期化時に現在の値を取得する。HPや何たらゲージみたいな、毎フレーム加算/減算される値。
        private float _phantasmaVigoris;
        private float _phantasmaPatientiae;
        private float _phantasmaAether;

        // 固定変動値
        // 初期化時に0fにされる。フレーム毎に状態により固定の値が決まる。
        private float _phantasmaClaritas;
        private float _phantasmaIntentio;

        private float _vigorMaxima;
        private float _patientiaMaxima;
        private float _claritasMaxima;
        private float _atherirMaxima;
        private float _intentioMaxima;

        public MilesPuellaeVeletudinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;

            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaClaritas = 0f;
            _phantasmaAether = 0f;
            _phantasmaIntentio = 0f;

            _vigorMaxima = 1f;
            _patientiaMaxima = 1f;
            _claritasMaxima = 1f;
            _atherirMaxima = 1f;
            _intentioMaxima = 1f;
        }

        // phantasmaの値を初期化。
        public void InitarePhantasma(ResFluidaPuellaeVeletudinis resFluida) {
            _phantasmaVigoris = resFluida.Vigor;
            _phantasmaPatientiae = resFluida.Patientia;
            _phantasmaAether = resFluida.Aether;
            _phantasmaClaritas = 0f;
            _phantasmaIntentio = 0f;
        }

        // 変動値の加算。
        public void Addo(in OrdinatioPuellaeVeletudinis ordinatio) {
            _phantasmaVigoris += ordinatio.DtVigoris;
            _phantasmaPatientiae += ordinatio.DtPatientiae;
            _phantasmaAether += ordinatio.DtAetheris;
            _phantasmaIntentio += ordinatio.DtIntentio;
            _phantasmaClaritas += ordinatio.DtClaritas;
        }

        // 値により確定するフラグの解決。
        public void Resolvere(ResFluidaPuellaeVeletudinis resFluida) {
            resFluida.ResolvereExhauritaVigoris(
                _contextusOstiorum.Configuratio.Veletudo.LimenExhauritaVigoris,
                _contextusOstiorum.Configuratio.Veletudo.LimenRefectaVigoris,
                _vigorMaxima
            );
            resFluida.ResolvereExhauritaPatientiae(
                _contextusOstiorum.Configuratio.Veletudo.LimenExhauritaPatientiae,
                _contextusOstiorum.Configuratio.Veletudo.LimenRefectaPatientiae,
                _patientiaMaxima
            );
        }

        // phantasmaの値をresFluidaに反映。
        public void Applicare(ResFluidaPuellaeVeletudinis resFluida) {
            resFluida.RenovareVigor(DuxMath.Clamp(_phantasmaVigoris, 0f, _vigorMaxima));
            resFluida.RenovarePatientia(DuxMath.Clamp(_phantasmaPatientiae, 0f, _patientiaMaxima));
            resFluida.RenovareAether(DuxMath.Clamp(_phantasmaAether, 0f, _atherirMaxima));
            resFluida.RenovareIntentio(DuxMath.Clamp(_phantasmaIntentio, 0f, _intentioMaxima));
            resFluida.RenovareClaritas(DuxMath.Clamp(_phantasmaClaritas, 0f, _claritasMaxima));
            Purgare();
        }

        // phantasmaの値をリセット。
        // 注意: 完全初期化時以外に使用しない。
        // Pulsus()先頭で実行する初期化はInitarePhantasma()を使用する。
        private void Purgare() {
            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaAether = 0f;
            _phantasmaIntentio = 0f;
            _phantasmaClaritas = 0f;
        }
    }
}
