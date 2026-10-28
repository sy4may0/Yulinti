using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeDedecorisMaximum : IResolutorPuellaeDedecorisMaximum {
        public float Resolvere() {
            // Dedecusは固定
            float maximus = PuellaVeletudinis.DedecusMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}
