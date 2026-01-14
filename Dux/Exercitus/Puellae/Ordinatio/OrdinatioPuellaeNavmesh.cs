using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaeNavmesh : OrdinatioPuellae, IOrdinatioPuellaeNavmesh {
        private Vector3 _positio;
        private float _velocitasDesiderata;
        private float _acceleratio;
        private float _velocitasRotationis;
        private float _distantiaDeaccelerationis;

        public OrdinatioPuellaeNavmesh()
            : base(true, SpeciesOrdinatioPuellae.ActioNavmesh) {
            _positio = default;
            _velocitasDesiderata = 0f;
            _acceleratio = 0f;
            _velocitasRotationis = 0f;
            _distantiaDeaccelerationis = 0f;
        }

        public Vector3 Positio => _positio;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float VelocitasRotationis => _velocitasRotationis;
        public float DistantiaDeaccelerationis => _distantiaDeaccelerationis;

        public override void Purgere() {
            _estApplicandum = false;
            _positio = default;
            _velocitasDesiderata = 0f;
            _acceleratio = 0f;
            _velocitasRotationis = 0f;
            _distantiaDeaccelerationis = 0f;
        }

        public void Pono(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            float velocitasRotationis,
            float distantiaDeaccelerationis
        ) {
            _positio = positio;
            _velocitasDesiderata = velocitasDesiderata;
            _acceleratio = accelerationem;
            _velocitasRotationis = velocitasRotationis;
            _distantiaDeaccelerationis = distantiaDeaccelerationis;

            _estApplicandum = true;
        }
    }
}
