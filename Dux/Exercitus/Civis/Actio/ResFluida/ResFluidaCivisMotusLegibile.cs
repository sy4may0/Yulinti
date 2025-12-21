namespace Yulinti.Dux.Exercitus {
    public sealed class ResFluidaCivisMotusLegibile {
        private readonly ResFluidaCivisMotus _resFluida;

        public ResFluidaCivisMotusLegibile(ResFluidaCivisMotus resFluida) {
            _resFluida = resFluida;
        }

        public int IDPunctumViaeActualis => _resFluida.IDPunctumViaeActualis;
        public int IDPunctumViaeProximus => _resFluida.IDPunctumViaeProximus;
        public float VelocitasActualisHorizontalis => _resFluida.VelocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _resFluida.VelocitasActualisVerticalis;
        public float RotatioYActualis => _resFluida.RotatioYActualis;
        public bool EstInTerra => _resFluida.EstInTerra;
    }
}