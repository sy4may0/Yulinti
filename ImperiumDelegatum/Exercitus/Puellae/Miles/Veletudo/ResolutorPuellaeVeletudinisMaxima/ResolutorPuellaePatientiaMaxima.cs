using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaePatientiaeMaxima : IResolutorPuellaePatientiaeMaxima {
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaePatientiaeMaxima(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.PatientiaMaximaBasis;
            }

            // patientiaはとりあえず100固定
            float maximus = PuellaVeletudinis.PatientiaMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            return maximus * ratio;
        }
    }
}