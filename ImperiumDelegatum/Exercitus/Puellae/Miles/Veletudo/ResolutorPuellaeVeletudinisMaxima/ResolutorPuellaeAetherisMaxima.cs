using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeAetherisMaxima : IResolutorPuellaeAetherisMaxima {
        private readonly IPhantasmaPuellaePersonaeLegibile _phantasmaPuellaePersonae;

        public ResolutorPuellaeAetherisMaxima(IPhantasmaPuellaePersonaeLegibile phantasmaPuellaePersonae) {
            _phantasmaPuellaePersonae = phantasmaPuellaePersonae;
        }

        public float Resolvere() {
            float maximus = PuellaVeletudinis.AetherMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // Luxurious Level 5以上で+100%
            if (_phantasmaPuellaePersonae.GradusLuxuriosus >= 5) {
                ratio += 1.0f;
            }

            return maximus * ratio;
        }
    }
}
