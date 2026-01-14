namespace Yulinti.Dux.Exercitus {

    internal sealed class PhantasmaPuellaeVeletudinis {
        private float _phantasmaVigoris;
        private float _phantasmaPatientiae;
        private float _phantasmaAether;
        private float _phantasmaClaritas;
        private float _phantasmaIntentio;

        private float _vigorMaxima;
        private float _patientiaMaxima;
        private float _claritasMaxima;
        private float _aetherMaxima;
        private float _intentioMaxima;

        public PhantasmaPuellaeVeletudinis() {
            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaAether = 0f;
            _phantasmaClaritas = 0f;
            _phantasmaIntentio = 0f;

            // 将来Config取得とかに変わるかもしれないので、やりやすいように値にしておく。
            _vigorMaxima = 1f;
            _patientiaMaxima = 1f;
            _claritasMaxima = 1f;
            _aetherMaxima = 1f;
            _intentioMaxima = 1f;
        }

        public float PhantasmaVigoris => _phantasmaVigoris;
        public float PhantasmaPatientiae => _phantasmaPatientiae;
        public float PhantasmaAether => _phantasmaAether;
        public float PhantasmaClaritas => _phantasmaClaritas;
        public float PhantasmaIntentio => _phantasmaIntentio;

        public void Addo(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAether = 0f,
            float dtClaritas = 0f,
            float dtIntentio = 0f
        ) {
            _phantasmaVigoris = DuxMath.Clamp(_phantasmaVigoris + dtVigoris, 0f, _vigorMaxima);
            _phantasmaPatientiae = DuxMath.Clamp(_phantasmaPatientiae + dtPatientiae, 0f, _patientiaMaxima);
            _phantasmaAether = DuxMath.Clamp(_phantasmaAether + dtAether, 0f, _aetherMaxima);
            _phantasmaClaritas = DuxMath.Clamp(_phantasmaClaritas + dtClaritas, 0f, _claritasMaxima);
            _phantasmaIntentio = DuxMath.Clamp(_phantasmaIntentio + dtIntentio, 0f, _intentioMaxima);
        }

        public void Pono(
            float vigor,
            float patientia,
            float aether,
            float claritas,
            float intentio
        ) {
            _phantasmaVigoris = DuxMath.Clamp(vigor, 0f, _vigorMaxima);
            _phantasmaPatientiae = DuxMath.Clamp(patientia, 0f, _patientiaMaxima);
            _phantasmaAether = DuxMath.Clamp(aether, 0f, _aetherMaxima);
            _phantasmaClaritas = DuxMath.Clamp(claritas, 0f, _claritasMaxima);
            _phantasmaIntentio = DuxMath.Clamp(intentio, 0f, _intentioMaxima);
        }
    }

    internal sealed class ExecutorPuellaeVeletudinis : IExecutorPuellae {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly ResFluidaPuellaeVeletudinis _resFluidaVeletudinis;

        private readonly PhantasmaPuellaeVeletudinis _phantasma;

        public ExecutorPuellaeVeletudinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ResFluidaPuellaeVeletudinis resFluidaVeletudinis
        ) {
            _contextusOstiorum = contextusOstiorum;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _phantasma = new PhantasmaPuellaeVeletudinis();
        }

        public void Primum() {
            _phantasma.Pono(
                vigor: _resFluidaVeletudinis.Vigor,
                patientia: _resFluidaVeletudinis.Patientia,
                aether: _resFluidaVeletudinis.Aether,
                claritas: 0f,
                intentio: 0f
            );
        }

        public void Executare(
            IOrdinatioPuellaeVeletudinis veletudinis
        ) {
            _phantasma.Addo(
                dtVigoris: veletudinis.DtVigoris,
                dtPatientiae: veletudinis.DtPatientiae,
                dtAether: veletudinis.DtAetheris,
                dtClaritas: veletudinis.DtClaritas,
                dtIntentio: veletudinis.DtIntentio
            );
        }

        public void Confirmare() {
            _resFluidaVeletudinis.RenovareVigor(_phantasma.PhantasmaVigoris);
            _resFluidaVeletudinis.RenovarePatientia(_phantasma.PhantasmaPatientiae);
            _resFluidaVeletudinis.RenovareAether(_phantasma.PhantasmaAether);
            _resFluidaVeletudinis.RenovareClaritas(_phantasma.PhantasmaClaritas);
            _resFluidaVeletudinis.RenovareIntentio(_phantasma.PhantasmaIntentio);

            _resFluidaVeletudinis.ResolvereExhauritaVigoris(
                _contextusOstiorum.Configuratio.Veletudo.LimenExhauritaVigoris,
                _contextusOstiorum.Configuratio.Veletudo.LimenRefectaVigoris,
                1f // VigorMaxima Config設定可能にするならここを変える。
            );
            _resFluidaVeletudinis.ResolvereExhauritaPatientiae(
                _contextusOstiorum.Configuratio.Veletudo.LimenExhauritaPatientiae,
                _contextusOstiorum.Configuratio.Veletudo.LimenRefectaPatientiae,
                1f // PatientiaMaxima Config設定可能にするならここを変える。
            );
        }

        public void Purgare() {
            _phantasma.Pono(
                vigor: 0f,
                patientia: 0f,
                aether: 0f,
                claritas: 0f,
                intentio: 0f
            );
        }
    }
}