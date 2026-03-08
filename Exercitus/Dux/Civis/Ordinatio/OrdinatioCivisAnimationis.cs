using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class OrdinatioCivisAnimationis : OrdinatioCivis, IOrdinatioCivisAnimationis {
        private IDCivisAnimationisStratum _stratum;
        private IDCivisAnimationis _idAnimationis;

        public OrdinatioCivisAnimationis(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.ActioAnimationis) {
            _stratum = default;
            _idAnimationis = default;
        }

        public IDCivisAnimationisStratum Stratum => _stratum;
        public IDCivisAnimationis IdAnimationis => _idAnimationis;

        public override void Purgere() {
            _estApplicandum = false;
            _stratum = default;
            _idAnimationis = default;
        }

        public void Pono(
            IDCivisAnimationisStratum stratum,
            IDCivisAnimationis idAnimationis
        ) {
            _estApplicandum = true;
            _stratum = stratum;
            _idAnimationis = idAnimationis;
        }
    }
}
