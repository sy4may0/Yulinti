namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeVeletudinis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        private float _phantasmaVigoris;
        private float _phantasmaPatientiae;
        private float _phantasmaClaritas;
        private float _phantasmaAether;
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

        public void InitarePhantasma(in ResFluidaPuellaeVeletudinis resFluida) {
            _phantasmaVigoris = resFluida.Vigor;
            _phantasmaPatientiae = resFluida.Patientia;
            _phantasmaClaritas = resFluida.Claritas;
            _phantasmaAether = resFluida.Aether;
            _phantasmaIntentio = resFluida.Intentio;
        }

        public void Addo(OrdinatioPuellaeVeletudinis ordinatio) {
            _phantasmaVigoris += ordinatio.DtVigoris;
            _phantasmaPatientiae += ordinatio.DtPatientiae;
            _phantasmaClaritas += ordinatio.DtClaritatis;
            _phantasmaAether += ordinatio.DtAetheris;
            _phantasmaIntentio = ordinatio.Intentio;
            _phantasmaClaritas = ordinatio.Claritas;
        }

        public void Resolvere(in ResFluidaPuellaeVeletudinis resFluida) {
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

        public void Applicare(in ResFluidaPuellaeVeletudinis resFluida) {
            resFluida.RenovareVigor(DuxMath.Clamp(_phantasmaVigoris, 0f, _vigorMaxima));
            resFluida.RenovarePatientia(DuxMath.Clamp(_phantasmaPatientiae, 0f, _patientiaMaxima));
            resFluida.RenovareClaritas(DuxMath.Clamp(_phantasmaClaritas, 0f, _claritasMaxima));
            resFluida.RenovareAether(DuxMath.Clamp(_phantasmaAether, 0f, _atherirMaxima));
            resFluida.RenovareIntentio(DuxMath.Clamp(_phantasmaIntentio, 0f, _intentioMaxima));
            resFluida.RenovareClaritas(DuxMath.Clamp(_phantasmaClaritas, 0f, _claritasMaxima));
            Purgare();
        }

        private void Purgare() {
            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaClaritas = 0f;
            _phantasmaAether = 0f;
            _phantasmaIntentio = 0f;
            _phantasmaClaritas = 0f;
        }
    }
}