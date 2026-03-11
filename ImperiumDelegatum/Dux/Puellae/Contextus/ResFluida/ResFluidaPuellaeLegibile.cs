using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaPuellaeLegibile : IResFluidaPuellaeLegibile {
        private readonly IResFluidaPuellaeMotusLegibile _motus;
        private readonly IResFluidaPuellaeVeletudinisLegibile _veletudinis;
        private readonly IResFluidaPuellaeSpectaculiLegibile _spectaculum;

        public ResFluidaPuellaeLegibile(
            IResFluidaPuellaeMotusLegibile motus,
            IResFluidaPuellaeVeletudinisLegibile veletudinis,
            IResFluidaPuellaeSpectaculiLegibile spectaculum
        ) {
            _motus = motus;
            _veletudinis = veletudinis;
            _spectaculum = spectaculum;
        }

        public IResFluidaPuellaeMotusLegibile Motus => _motus;
        public IResFluidaPuellaeVeletudinisLegibile Veletudinis => _veletudinis;
        public IResFluidaPuellaeSpectaculiLegibile Spectaculum => _spectaculum;
    }
}