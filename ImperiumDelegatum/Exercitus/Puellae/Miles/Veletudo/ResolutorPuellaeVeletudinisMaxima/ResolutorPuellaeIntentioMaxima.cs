using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeIntentioMaxima : IResolutorPuellaeIntentioMaxima {
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaeIntentioMaxima(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.IntentioMaximaBasis;
            }

            float maximus = PuellaVeletudinis.IntentioMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // luxurious level * 20%
            if (actualis.PuellaePersonae.GradusLuxuriosus > 0) {
                ratio += (actualis.PuellaePersonae.GradusLuxuriosus - 1) * 0.20f;
            }

            // exhibitus level * 15%
            if (actualis.PuellaePersonae.GradusExhibitus > 0) {
                ratio += (actualis.PuellaePersonae.GradusExhibitus - 1) * 0.15f;
            }

            // perversus level * 10%
            if (actualis.PuellaePersonae.GradusPerversus > 0) {
                ratio += (actualis.PuellaePersonae.GradusPerversus - 1) * 0.10f;
            }

            // quaerit dolore level * 5%
            if (actualis.PuellaePersonae.GradusQuaeritDolore > 0) {
                ratio += (actualis.PuellaePersonae.GradusQuaeritDolore - 1) * 0.05f;
            }

            return maximus * ratio;
        }
    }
}