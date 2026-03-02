using System.Numerics;

namespace Yulinti.Exercitus.Dux {
    internal sealed class OrdinatioPuellaeNavmeshInitii : OrdinatioPuellaeInitii, IOrdinatioPuellaeNavmeshInitii {
        private Vector3 _positio;
        private Quaternion _rotatio;

        public OrdinatioPuellaeNavmeshInitii()
            : base(true, SpeciesOrdinatioPuellae.ActioNavmeshInitii) {
            _positio = default;
            _rotatio = default;
        }

        public Vector3 Positio => _positio;
        public Quaternion Rotatio => _rotatio;

        public override void Purgere() {
            _estApplicandum = false;
            _positio = default;
            _rotatio = default;
        }

        public void Pono(
            Vector3 positio,
            Quaternion rotatio
        ) {
            _positio = positio;
            _rotatio = rotatio;
            _estApplicandum = true;
        }
    }
}
