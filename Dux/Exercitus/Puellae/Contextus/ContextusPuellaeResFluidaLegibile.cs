namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusPuellaeResFluidaLegibile {
        private readonly ResFluidaPuellae _resFluida;
        private readonly ResFluidaPuellaeMotus _motus;

        public ContextusPuellaeResFluidaLegibile(
            ResFluidaPuellae resFluida,
            ResFluidaPuellaeMotus motus
        ) {
            _resFluida = resFluida;
            _motus = motus;
        }

        public float Vigor => _resFluida.Vigor;
        public float Patientia => _resFluida.Patientia;
        public float Claritas => _resFluida.Claritas;
        public float Aether => _resFluida.Aether;
        public float Intentio => _resFluida.Intentio;
        public bool EstExhauritaVigoris => _resFluida.EstExhauritaVigoris();
        public bool EstExhauritaPatientiae => _resFluida.EstExhauritaPatientiae();

        public float VelocitasActualisHorizontalis => _motus.VelocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _motus.VelocitasActualisVerticalis;
        public float RotatioYActualis => _motus.RotatioYActualis;
        public bool EstInTerra => _motus.EstInTerra;

    }
}