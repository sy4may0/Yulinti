using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeClaritatisMaximus : IResolutorPuellaeClaritatisMaximus {
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaeClaritatisMaximus(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.ClaritasMaximaBasis;
            }

            // Claritasはとりあえず100固定
            float maximus = PuellaVeletudinis.ClaritasMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}