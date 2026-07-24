using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaCivisLegibile : IResFluidaCivisLegibile {
        private readonly IResFluidaCivisMotusLegibile _motus;
        private readonly IResFluidaCivisVeletudinisLegibile _veletudinis;
        private readonly IResFluidaCivisCustodiaeLegibile _custodiae;

        public ResFluidaCivisLegibile(
            IResFluidaCivisMotusLegibile motus,
            IResFluidaCivisVeletudinisLegibile veletudinis,
            IResFluidaCivisCustodiaeLegibile custodiae
        ) {
            _motus = motus;
            _veletudinis = veletudinis;
            _custodiae = custodiae;
        }

        public IResFluidaCivisMotusLegibile Motus => _motus;
        public IResFluidaCivisVeletudinisLegibile Veletudinis => _veletudinis;
        public IResFluidaCivisCustodiaeLegibile Custodiae => _custodiae;
    }
}