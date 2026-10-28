using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeVigorisMaxima : IResolutorPuellaeVigorisMaxima {
        private readonly IPhantasmaPuellaePersonaeLegibile _phantasmaPuellaePersonae;

        public ResolutorPuellaeVigorisMaxima(IPhantasmaPuellaePersonaeLegibile phantasmaPuellaePersonae) {
            _phantasmaPuellaePersonae = phantasmaPuellaePersonae;
        }

        public float Resolvere() {
            float maximus = PuellaVeletudinis.VigorMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // -1は初期レベル減算
            // Luxurious Level * 5%
            if (_phantasmaPuellaePersonae.GradusLuxuriosus > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusLuxuriosus - 1) * 0.05f;
            }

            // Exhibitus Level * 10%
            if (_phantasmaPuellaePersonae.GradusExhibitus > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusExhibitus - 1) * 0.10f;
            }

            // Perversus Level * 10%
            if (_phantasmaPuellaePersonae.GradusPerversus > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusPerversus - 1) * 0.10f;
            }

            // Quaerit Dolore Level * 20%
            if (_phantasmaPuellaePersonae.GradusQuaeritDolore > 0) {
                ratio += (_phantasmaPuellaePersonae.GradusQuaeritDolore - 1) * 0.20f;
            }

            return maximus * ratio;
        }
    }
}
