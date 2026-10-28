using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaePatientiaeMaxima : IResolutorPuellaePatientiaeMaxima {
        public float Resolvere() {
            // patientiaはとりあえず100固定
            float maximus = PuellaVeletudinis.PatientiaMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}
