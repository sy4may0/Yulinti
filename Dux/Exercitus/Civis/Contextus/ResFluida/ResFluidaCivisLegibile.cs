using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivisLegibile : IResFluidaCivisLegibile {
        private readonly IResFluidaCivisMotusLegibile _motus;
        private readonly IResFluidaCivisVeletudinisLegibile _veletudinis;

        public ResFluidaCivisLegibile(
            IResFluidaCivisMotusLegibile motus,
            IResFluidaCivisVeletudinisLegibile veletudinis
        ) {
            _motus = motus;
            _veletudinis = veletudinis;
        }

        public IResFluidaCivisMotusLegibile Motus => _motus;
        public IResFluidaCivisVeletudinisLegibile Veletudinis => _veletudinis;
    }
}