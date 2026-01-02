namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeVeletudinis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly ResolutorPuellaeVeletudinis _resolutorVeletudinis;

        public MilesPuellaeVeletudinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _resolutorVeletudinis = new ResolutorPuellaeVeletudinis();
            _contextusOstiorum = contextusOstiorum;
        }

        public void InitarePhantasma(in ResFluidaPuellaeVeletudinis resFluida) {
            _resolutorVeletudinis.InitarePhantasma(resFluida);
        }

        public void Addo(OrdinatioPuellaeVeletudinis ordinatio) {
            _resolutorVeletudinis.Addo(ordinatio);
        }

        public void Resolvere(in ResFluidaPuellaeVeletudinis resFluida) {
            _resolutorVeletudinis.Resolvere(_contextusOstiorum, in resFluida);

        }

        public void Applicare(in ResFluidaPuellaeVeletudinis resFluida) {
            _resolutorVeletudinis.Applicare(in resFluida);
        }
    }
}