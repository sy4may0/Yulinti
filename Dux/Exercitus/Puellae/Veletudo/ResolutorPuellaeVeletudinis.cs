using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorPuellaeVeletudinis {
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

        public ResolutorPuellaeVeletudinis() {
            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaClaritas = 0f;
            _phantasmaAether = 0f;
            _phantasmaIntentio = 0f;

            _vigorMaxima = 100;
            _patientiaMaxima = 100;
            _claritasMaxima = 100;
            _atherirMaxima = 100;
            _intentioMaxima = 100;
        }

        public void InitarePhantasma(
            in ResFluidaPuellaeVeletudinis resFluida
        ) {
            _phantasmaVigoris = resFluida.Vigor;
            _phantasmaPatientiae = resFluida.Patientia;
            _phantasmaClaritas = resFluida.Claritas;
            _phantasmaAether = resFluida.Aether;
            _phantasmaIntentio = resFluida.Intentio;
        }

        public void Resolvere(OrdinatioPuellaeVeletudinis ordinatio) {
            _phantasmaVigoris += ordinatio.DtVigoris;
            _phantasmaPatientiae += ordinatio.DtPatientiae;
            _phantasmaClaritas += ordinatio.DtClaritatis;
            _phantasmaAether += ordinatio.DtAetheris;
            _phantasmaIntentio += ordinatio.DtIntentionis;
        }

        public void Applicare(in ResFluidaPuellaeVeletudinis resFluida) {
            resFluida.RenovareVigor(DuxMath.Clamp(_phantasmaVigoris, 0f, _vigorMaxima));
            resFluida.RenovarePatientia(DuxMath.Clamp(_phantasmaPatientiae, 0f, _patientiaMaxima));
            resFluida.RenovareClaritas(DuxMath.Clamp(_phantasmaClaritas, 0f, _claritasMaxima));
            resFluida.RenovareAether(DuxMath.Clamp(_phantasmaAether, 0f, _atherirMaxima));
            resFluida.RenovareIntentio(DuxMath.Clamp(_phantasmaIntentio, 0f, _intentioMaxima));
            Purgare();
        }

        public void Purgare() {
            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaClaritas = 0f;
            _phantasmaAether = 0f;
            _phantasmaIntentio = 0f;
        }
    }
}