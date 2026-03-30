using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorPuellaeDedecorisMaximum : IResolutorPuellaeDedecorisMaximum {
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;

        public ResolutorPuellaeDedecorisMaximum(ITurrisSalsamentiLegibile turrisSalsamenti) {
            _turrisSalsamenti = turrisSalsamenti;
        }

        public float Resolvere() {
            if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                return PuellaVeletudinis.DedecusMaximaBasis;
            }

            float maximus = PuellaVeletudinis.DedecusMaximaBasis; // 規定値
            float ratio = 1.0f; // 補正倍率

            // luxurious level * 5%
            if (actualis.PuellaePersonae.GradusLuxuriosus > 0) {
                ratio += (actualis.PuellaePersonae.GradusLuxuriosus - 1) * 0.05f;
            }

            // exhibitus level * 10%
            if (actualis.PuellaePersonae.GradusExhibitus > 0) {
                ratio += (actualis.PuellaePersonae.GradusExhibitus - 1) * 0.10f;
            }

            // perversus level * 20%
            if (actualis.PuellaePersonae.GradusPerversus > 0) {
                ratio += (actualis.PuellaePersonae.GradusPerversus - 1) * 0.20f;
            }

            // quaerit dolore level * 25%
            if (actualis.PuellaePersonae.GradusQuaeritDolore > 0) {
                ratio += (actualis.PuellaePersonae.GradusQuaeritDolore - 1) * 0.25f;
            }

            // quaerit dolore , perversus, exhibitusがすべて10以上で制限除去(無限表示)
            if (
               actualis.PuellaePersonae.GradusExhibitus >= 10 && 
               actualis.PuellaePersonae.GradusPerversus >= 10 && 
               actualis.PuellaePersonae.GradusQuaeritDolore >= 10
            ) {
                maximus = PuellaVeletudinis.DedecusInfinitionis;
            }

            return maximus * ratio;
        }
    }
}