using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeAetherisMaxima : IResolutorPuellaeAetherisMaxima {
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaeAetherisMaxima(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.AetherMaximaBasis;
            }

            float maximus = PuellaVeletudinis.AetherMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // Luxurious Level 5以上で+100%
            if (actualis.PuellaePersonae.GradusLuxuriosus >= 5) {
                ratio += 1.0f;
            }

            return maximus * ratio;
        }
    }
}