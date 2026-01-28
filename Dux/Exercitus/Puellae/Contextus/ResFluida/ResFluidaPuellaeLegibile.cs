using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaPuellaeLegibile : IResFluidaPuellaeLegibile {
        private readonly IResFluidaPuellaeMotusLegibile _motus;
        private readonly IResFluidaPuellaeVeletudinisLegibile _veletudinis;
        private readonly IResFluidaPuellaePersonaeLegibile _persona;

        public ResFluidaPuellaeLegibile(
            IResFluidaPuellaeMotusLegibile motus,
            IResFluidaPuellaeVeletudinisLegibile veletudinis,
            IResFluidaPuellaePersonaeLegibile persona
        ) {
            _motus = motus;
            _veletudinis = veletudinis;
            _persona = persona;
        }

        public IResFluidaPuellaeMotusLegibile Motus => _motus;
        public IResFluidaPuellaeVeletudinisLegibile Veletudinis => _veletudinis;
        public IResFluidaPuellaePersonaeLegibile Persona => _persona;
    }
}