using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaPuellaeVeletudinis : IResFluidaPuellaeVeletudinisLegibile {
        // health
        private float vigor;
        private bool estExhauritaVigoris;

        // stamina
        private float patientia;
        private bool estExhauritaPatientiae;

        // visibility(0~100)
        private float claritas;
        // electricity
        private float aether;
        // voltage
        private float intentio;


        public ResFluidaPuellaeVeletudinis() {
            this.vigor = 100;
            this.patientia = 100;
            this.claritas = 100;
            this.aether = 100;
            this.intentio = 100;
        }

        public float Vigor => vigor;
        public bool EstExhauritaVigoris => estExhauritaVigoris;
        public float Patientia => patientia;
        public bool EstExhauritaPatientiae => estExhauritaPatientiae;
        public float Claritas => claritas;
        public float Aether => aether;
        public float Intentio => intentio;

        public void RenovareVigor(float valor) {
            vigor = valor;
        }
        public void RenovarePatientia(float valor) {
            patientia = valor;
        }
        public void RenovareClaritas(float valor) {
            claritas = valor;
        }
        public void RenovareAether(float valor) {
            aether = valor;
        }
        public void RenovareIntentio(float valor) {
            intentio = valor;
        }

        public void ResolvereExhauritaVigoris(
            float LimenExhauritaVigoris,
            float LimenRefectaVigoris,
            float VigorMaxima
        ) {
            float limenEx = VigorMaxima * LimenExhauritaVigoris;
            if (!estExhauritaVigoris && vigor <= limenEx) {
                estExhauritaVigoris = true;
            }

            float limenRe = VigorMaxima * LimenRefectaVigoris;
            if (estExhauritaVigoris && vigor >= limenRe) {
                estExhauritaVigoris = false;
            }
        }

        public void ResolvereExhauritaPatientiae(
            float LimenExhauritaPatientiae,
            float LimenRefectaPatientiae,
            float PatientiaMaxima
        ) {
            float limenEx = PatientiaMaxima * LimenExhauritaPatientiae;
            if (!estExhauritaPatientiae && patientia <= limenEx) {
                estExhauritaPatientiae = true;
            }

            float limenRe = PatientiaMaxima * LimenRefectaPatientiae;
            if (estExhauritaPatientiae && patientia >= limenRe) {
                estExhauritaPatientiae = false;
            }
        }
    }
}