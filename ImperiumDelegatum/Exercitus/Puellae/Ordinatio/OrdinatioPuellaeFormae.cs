using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioPuellaeFormae : OrdinatioPuellae, IOrdinatioPuellaeFormae {
        private IDPuellaeFormae _idFormae;
        private float _ratioDesiderata;

        public OrdinatioPuellaeFormae()
            : base(true, SpeciesOrdinatioPuellae.Formae) {
            _idFormae = IDPuellaeFormae.Corpus;
            _ratioDesiderata = 0.5f;
        }

        public IDPuellaeFormae IdFormae => _idFormae;
        public float RatioDesiderata => _ratioDesiderata;

        public override void Purgere() {
            _estApplicandum = false;
            _idFormae = IDPuellaeFormae.Corpus;
            _ratioDesiderata = 0.5f;
        }

        public void Pono(
            IDPuellaeFormae idFormae,
            float ratioDesiderata
        ) {
            _idFormae = idFormae;
            _ratioDesiderata = ratioDesiderata;
            _estApplicandum = true;
        }
    }
}