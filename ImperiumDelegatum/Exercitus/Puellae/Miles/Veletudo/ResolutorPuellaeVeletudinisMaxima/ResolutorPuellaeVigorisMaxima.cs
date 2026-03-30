using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeVigorisMaxima : IResolutorPuellaeVigorisMaxima {
        // GradusによってVigorisMaximaを計算する。
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaeVigorisMaxima(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            // セーブデータが無い場合(異常)もデフォルト100。
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.VigorMaximaBasis;
            }

            float maximus = PuellaVeletudinis.VigorMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // -1は初期レベル減算
            // Luxurious Level * 5%
            if (actualis.PuellaePersonae.GradusLuxuriosus > 0) {
                ratio += (actualis.PuellaePersonae.GradusLuxuriosus - 1) * 0.05f;
            }

            // Exhibitus Level * 10%
            if (actualis.PuellaePersonae.GradusExhibitus > 0) {
                ratio += (actualis.PuellaePersonae.GradusExhibitus - 1) * 0.10f;
            }

            // Perversus Level * 10%
            if (actualis.PuellaePersonae.GradusPerversus > 0) {
                ratio += (actualis.PuellaePersonae.GradusPerversus - 1) * 0.10f;
            }

            // Quaerit Dolore Level * 20%
            if (actualis.PuellaePersonae.GradusQuaeritDolore > 0) {
                ratio += (actualis.PuellaePersonae.GradusQuaeritDolore - 1) * 0.20f;
            }

            return maximus * ratio;
        }
    }
}