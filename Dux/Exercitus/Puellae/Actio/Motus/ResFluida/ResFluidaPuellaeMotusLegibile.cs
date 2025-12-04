namespace Yulinti.Dux.Exercitus {
    internal class ResFluidaPuellaeMotusLegibile : IResFluidaPuellaeMotusLegibile
    {
        private readonly ResFluidaPuellaeMotus _resFluida;

        public ResFluidaPuellaeMotusLegibile(ResFluidaPuellaeMotus resFluida)
        {
            _resFluida = resFluida;
        }

        public float VelocitasActualisHorizontalis => _resFluida.VelocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _resFluida.VelocitasActualisVerticalis;
        public float RotatioYActualis => _resFluida.RotatioYActualis;
        public bool EstInTerra => _resFluida.EstInTerra;
    }
}
