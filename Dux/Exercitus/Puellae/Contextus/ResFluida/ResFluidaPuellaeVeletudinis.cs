using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaPuellaeVeletudinis {
        // health(0~100)
        private float vigor;
        // stamina(0~100)
        private float patientia;
        // visibility(0~100)
        private float claritas;
        // electricity(0~100)
        private float aether;
        // voltage(0~100)
        private float intentio;


        public ResFluidaPuellaeVeletudinis() {
            this.vigor = 100;
            this.patientia = 100;
            this.claritas = 100;
            this.aether = 100;
            this.intentio = 100;
        }

        public float Vigor => vigor;
        public float Patientia => patientia;
        public float Claritas => claritas;
        public float Aether => aether;
        public float Intentio => intentio;

        public void IncrementareVigoris(float valor) {
            vigor += valor;
        }
        public void IncrementarePatientiae(float valor) {
            patientia += valor;
        }
        public void IncrementareClaritatis(float valor) {
            claritas += valor;
        }
        public void IncrementareAetheris(float valor) {
            aether += valor;
        }
        public void RenovareIntentio(float valor) {
            intentio = valor;
        }
    }
}