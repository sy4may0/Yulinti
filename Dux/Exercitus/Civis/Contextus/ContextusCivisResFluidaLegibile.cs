namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusCivisResFluidaLegibile {
        private readonly ResFluidaCivis _resFluida;

        public ContextusCivisResFluidaLegibile(
            ResFluidaCivis resFluida
        ) {
            _resFluida = resFluida;
        }

        public int IDCivis => _resFluida.IDCivis;

        public int Vitae => _resFluida.Vitae;
        public bool EstDominare => _resFluida.EstDominare;
        public int IDPunctumViaeActualis => _resFluida.IDPunctumViaeActualis;
        public int IDPunctumViaeProximus => _resFluida.IDPunctumViaeProximus;

        public float VelocitasActualisHorizontalis => _resFluida.VelocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _resFluida.VelocitasActualisVerticalis;
        public float RotatioYActualis => _resFluida.RotatioYActualis;
        public bool EstInTerra => _resFluida.EstInTerra;

        public bool EstExhauritaVitae() {
            return _resFluida.EstExhaurita();
        }
    }
}