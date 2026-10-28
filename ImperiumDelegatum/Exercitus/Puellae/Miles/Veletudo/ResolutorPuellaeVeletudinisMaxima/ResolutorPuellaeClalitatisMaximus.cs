using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeClaritatisMaximus : IResolutorPuellaeClaritatisMaximus {
        public float Resolvere() {
            // Claritasはとりあえず100固定
            float maximus = PuellaVeletudinis.ClaritasMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}
