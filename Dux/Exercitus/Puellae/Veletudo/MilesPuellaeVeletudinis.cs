namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeVeletudinis {
        private readonly ResolutorPuellaeVeletudinis _resolutorVeletudinis;

        public MilesPuellaeVeletudinis() {
            _resolutorVeletudinis = new ResolutorPuellaeVeletudinis();
        }

        public void InitarePhantasma(in ResFluidaPuellaeVeletudinis resFluida) {
            _resolutorVeletudinis.InitarePhantasma(resFluida);
        }

        public void Resolvere(OrdinatioPuellaeVeletudinis ordinatio) {
            _resolutorVeletudinis.Resolvere(ordinatio);
        }

        public void Applicare(in ResFluidaPuellaeVeletudinis resFluida) {
            _resolutorVeletudinis.Applicare(in resFluida);
        }
    }
}