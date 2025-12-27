namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusPuellaeResFluidaLegibile {
        private readonly ResFluidaPuellaeVeletudinis _veletudinis;
        private readonly ResFluidaPuellaeMotus _motus;

        public ContextusPuellaeResFluidaLegibile(
            ResFluidaPuellaeVeletudinis veletudinis,
            ResFluidaPuellaeMotus motus
        ) {
            _veletudinis = veletudinis;
            _motus = motus;
        }

        public float Vigor => _veletudinis.Vigor;
        public float Patientia => _veletudinis.Patientia;
        public float Claritas => _veletudinis.Claritas;
        public float Aether => _veletudinis.Aether;
        public float Intentio => _veletudinis.Intentio;

        public float VelocitasActualisHorizontalis => _motus.VelocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _motus.VelocitasActualisVerticalis;
        public float RotatioYActualis => _motus.RotatioYActualis;
        public bool EstInTerra => _motus.EstInTerra;

    }
}