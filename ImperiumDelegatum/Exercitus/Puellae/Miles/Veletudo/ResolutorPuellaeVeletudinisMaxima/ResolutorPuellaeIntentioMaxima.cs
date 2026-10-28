using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeIntentioMaxima : IResolutorPuellaeIntentioMaxima {
        private readonly IPhantasmaPuellaePersonaeLegibile _phantasmaPuellaePersonae;

        public ResolutorPuellaeIntentioMaxima(IPhantasmaPuellaePersonaeLegibile phantasmaPuellaePersonae) {
            _phantasmaPuellaePersonae = phantasmaPuellaePersonae;
        }

        public float Resolvere() {
            float maximus = PuellaVeletudinis.IntentioMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // luxurious level * 20%
            if (_phantasmaPuellaePersonae.GradusLuxuriosus > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusLuxuriosus - 1) * 0.20f;
            }

            // exhibitus level * 15%
            if (_phantasmaPuellaePersonae.GradusExhibitus > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusExhibitus - 1) * 0.15f;
            }

            // perversus level * 10%
            if (_phantasmaPuellaePersonae.GradusPerversus > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusPerversus - 1) * 0.10f;
            }

            // quaerit dolore level * 5%
            if (_phantasmaPuellaePersonae.GradusQuaeritDolore > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusQuaeritDolore - 1) * 0.05f;
            }

            return maximus * ratio;
        }
    }
}
