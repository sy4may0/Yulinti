using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeVeletudinisDedecoris {
        private readonly IConfiguratioPuellaeVeletudinis _configuratio;
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IResFluidaCivisCustodiaeLegibile _resFluidaCivisCustodiae;
        private readonly IOstiumCarrusPuellae _carrus;

        private readonly AbacusLenis _abacusNumerusVigilantiae;

        public MilesPuellaeVeletudinisDedecoris(
            IConfiguratioPuellaeVeletudinis configuratio,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusPuellae carrus
        ) {
            _configuratio = configuratio;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _resFluidaCivisCustodiae = resFluidaCivisCustodiae;
            _carrus = carrus;

            _abacusNumerusVigilantiae = new AbacusLenis(
                lenisMaxima: _configuratio.NumerusIctuumDedecorisMaxima,
                lenisMinima: 0f,
                praeruptioLenis: _configuratio.PraeruptioNumerusIctuumDedecoris
            );
        }

        public void Initare() {
            // 基本値を設定
            _carrus.PostulareVeletudinis(
                dtDedecus: 0f
            );
        }

        public void Ordinare() {
        }
    }
}