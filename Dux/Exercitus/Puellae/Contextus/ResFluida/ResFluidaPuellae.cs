using System;

namespace Yulinti.Dux.Exercitus {
    public struct OrdinatioResFluidaPuellae {
        public readonly float dtVigor;
        public readonly float dtPatientia;
        public readonly float dtClaritas;
        public readonly float dtAether;
        public readonly float dtIntentio;

        public OrdinatioResFluidaPuellae(
            float dtVigor,
            float dtPatientia,
            float dtClaritas,
            float dtAether,
            float dtIntentio
        ) {
            this.dtVigor = dtVigor;
            this.dtPatientia = dtPatientia;
            this.dtClaritas = dtClaritas;
            this.dtAether = dtAether;
            this.dtIntentio = dtIntentio;
        }
    }

    internal sealed class ResFluidaPuellae {
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


        public ResFluidaPuellae() {
            vigor = 100;
            patientia = 100;
            claritas = 100;
            aether = 100;
            intentio = 100;
        }

        public float Vigor => vigor;
        public float Patientia => patientia;
        public float Claritas => claritas;
        public float Aether => aether;
        public float Intentio => intentio;

        public void AddereVigor(float valor) {
            vigor = (float)Math.Clamp(vigor + valor, 0, 100);
        }

        public void AdderePatientia(float valor) {
            patientia = (float)Math.Clamp(patientia + valor, 0, 100);
        }

        public void AddereClaritas(float valor) {
            claritas = (float)Math.Clamp(claritas + valor, 0, 100);
        }

        public void AddereAether(float valor) {
            aether = (float)Math.Clamp(aether + valor, 0, 100);
        }
        
        public void AddereIntentio(float valor) {
            intentio = (float)Math.Clamp(intentio + valor, 0, 100);
        }

        public bool EstExhauritaVigoris() {
            return vigor <= 0;
        }

        public bool EstExhauritaPatientiae() {
            return patientia <= 0;
        }

        public void Renovare(OrdinatioResFluidaPuellae ordinatio) {
            vigor = (float)Math.Clamp(vigor + ordinatio.dtVigor, 0, 100);
            patientia = (float)Math.Clamp(patientia + ordinatio.dtPatientia, 0, 100);
            claritas = (float)Math.Clamp(claritas + ordinatio.dtClaritas, 0, 100);
            aether = (float)Math.Clamp(aether + ordinatio.dtAether, 0, 100);
            intentio = (float)Math.Clamp(intentio + ordinatio.dtIntentio, 0, 100);
        }
    }
}