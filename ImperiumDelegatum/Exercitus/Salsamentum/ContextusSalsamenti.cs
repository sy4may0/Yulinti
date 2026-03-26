using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusSalsamenti : IContextusSalsamenti {
        private readonly IPhantasmaPuellaePersonae _phantasmaPuellaePersonae;
        private readonly IResFluidaPuellaeFormaeLegibile _resFluidaPuellaeFormae;

        public ContextusSalsamenti(
            IPhantasmaPuellaePersonae phantasmaPuellaePersonae,
            IResFluidaPuellaeFormaeLegibile resFluidaPuellaeFormae
        ) {
            _phantasmaPuellaePersonae = phantasmaPuellaePersonae;
            _resFluidaPuellaeFormae = resFluidaPuellaeFormae;
        }

        public IPhantasmaPuellaePersonae PhantasmaPuellaePersonae => _phantasmaPuellaePersonae;
        public IResFluidaPuellaeFormaeLegibile ResFluidaPuellaeFormae => _resFluidaPuellaeFormae;
    }
}