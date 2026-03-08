using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class ResFluidaPuellaeSpectaculi : IResFluidaPuellaeSpectaculiLegibile {
        private IDPuellaeSpectaculiCorporis _idSpectaculiCorporis;

        public ResFluidaPuellaeSpectaculi() {
            _idSpectaculiCorporis = IDPuellaeSpectaculiCorporis.Formosa01;
        }

        public IDPuellaeSpectaculiCorporis IdSpectaculiCorporis => _idSpectaculiCorporis;

        public void RenovareIdSpectaculiCorporis(IDPuellaeSpectaculiCorporis idSpectaculiCorporis) {
            _idSpectaculiCorporis = idSpectaculiCorporis;
        }

        public void Purgare() {
            _idSpectaculiCorporis = IDPuellaeSpectaculiCorporis.Nihil;
        }
    }
}