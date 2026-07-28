using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisTorelantiaAnomaliaeMinimaMaxima : IResolutorCivisTorelantiaAnomaliaeMinimaMaxima {
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;

        public ResolutorCivisTorelantiaAnomaliaeMinimaMaxima(
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis
        ) {
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
        }

        public float Resolvere() {
            // PuellaeのAnomaliaMaximaと一致させる。
            return _resFluidaPuellaeVeletudinis.AnomaliaMaxima;
        }
    }
}
