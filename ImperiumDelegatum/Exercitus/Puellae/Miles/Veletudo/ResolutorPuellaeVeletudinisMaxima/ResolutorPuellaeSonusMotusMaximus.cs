using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeSonusMotusMaximus : IResolutorPuellaeSonusMotusMaximus {
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaeSonusMotusMaximus(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.SonusMotusMaximaBasis;
            }

            // SonusQuietesはとりあえず100固定
            float maximus = PuellaVeletudinis.SonusMotusMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}