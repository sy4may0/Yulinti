using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisTorelantiaAnomaliaeMaximaMaxima : IResolutorCivisTorelantiaAnomaliaeMaximaMaxima {
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;

        public ResolutorCivisTorelantiaAnomaliaeMaximaMaxima(
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
