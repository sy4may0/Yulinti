namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusPuellaeResFluidaLegibile {
        private readonly ResFluidaPuellaeMotus _motus;

        public ContextusPuellaeResFluidaLegibile(ResFluidaPuellaeMotus motus) {
            _motus = motus;
        }

        public float VelocitasActualisHorizontalis => _motus.VelocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _motus.VelocitasActualisVerticalis;
        public float RotatioYActualis => _motus.RotatioYActualis;
        public bool EstInTerra => _motus.EstInTerra;

    }
}