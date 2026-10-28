using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeSonusQuietesMaximus : IResolutorPuellaeSonusQuietesMaximus {
        public float Resolvere() {
            // SonusQuietesはとりあえず100固定
            float maximus = PuellaVeletudinis.SonusQuietesMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}
