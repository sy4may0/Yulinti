using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaPuellaeLegibile : IResFluidaPuellaeLegibile {
        private readonly IResFluidaPuellaeMotusLegibile _motus;
        private readonly IResFluidaPuellaeVeletudinisLegibile _veletudinis;

        public ResFluidaPuellaeLegibile(
            IResFluidaPuellaeMotusLegibile motus,
            IResFluidaPuellaeVeletudinisLegibile veletudinis
        ) {
            _motus = motus;
            _veletudinis = veletudinis;
        }

        public IResFluidaPuellaeMotusLegibile Motus => _motus;
        public IResFluidaPuellaeVeletudinisLegibile Veletudinis => _veletudinis;
    }
}