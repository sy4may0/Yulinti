using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioPuellaeFormae : OrdinatioPuellae, IOrdinatioPuellaeFormae {
        private IDPuellaeFormae _idFormae;
        private Vector3 _magnitudoDesiderata;

        public OrdinatioPuellaeFormae()
            : base(true, SpeciesOrdinatioPuellae.Formae) {
            _idFormae = IDPuellaeFormae.Corpus;
            _magnitudoDesiderata = new Vector3(1f, 1f, 1f);
        }

        public IDPuellaeFormae IdFormae => _idFormae;
        public Vector3 MagnitudoDesiderata => _magnitudoDesiderata;

        public override void Purgere() {
            _estApplicandum = false;
            _idFormae = IDPuellaeFormae.Corpus;
            _magnitudoDesiderata = new Vector3(1f, 1f, 1f);
        }

        public void Pono(
            IDPuellaeFormae idFormae,
            Vector3 magnitudoDesiderata
        ) {
            _idFormae = idFormae;
            _magnitudoDesiderata = magnitudoDesiderata;
            _estApplicandum = true;
        }
    }
}