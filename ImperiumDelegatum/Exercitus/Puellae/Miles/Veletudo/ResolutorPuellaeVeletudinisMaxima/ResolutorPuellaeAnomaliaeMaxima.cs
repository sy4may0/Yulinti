using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeAnomaliaeMaxima : IResolutorPuellaeAnomaliaeMaxima {
        public float Resolvere() {
            // Anomaliaは固定
            float maximus = PuellaVeletudinis.AnomaliaMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}
