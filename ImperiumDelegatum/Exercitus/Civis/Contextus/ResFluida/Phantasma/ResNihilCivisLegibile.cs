using Yulinti.ImperiumDelegatum.Contractus;

// NPCがいないところでNPC依存を解決するダミークラス。NPC0を返し、影響のない値を返すように。
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisLegibile : IResFluidaCivisLegibile {
        private readonly IResFluidaCivisMotusLegibile _motus;
        private readonly IResFluidaCivisVeletudinisLegibile _veletudinis;
        private readonly IResFluidaCivisCustodiaeLegibile _custodiae;

        public ResNihilCivisLegibile(
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