using Yulinti.ImperiumDelegatum.Contractus;

// NPCがいないところでNPC依存を解決するダミークラス。NPC0を返し、影響のない値を返すように。
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisLegibile : IResFluidaCivisLegibile {
        private readonly IResFluidaCivisMotusLegibile _motus;
        private readonly IResFluidaCivisVeletudinisLegibile _veletudinis;

        public ResNihilCivisLegibile(IResFluidaCivisMotusLegibile motus, IResFluidaCivisVeletudinisLegibile veletudinis) {
            _motus = motus;
            _veletudinis = veletudinis;
        }

        public IResFluidaCivisMotusLegibile Motus => _motus;
        public IResFluidaCivisVeletudinisLegibile Veletudinis => _veletudinis;
    }
}