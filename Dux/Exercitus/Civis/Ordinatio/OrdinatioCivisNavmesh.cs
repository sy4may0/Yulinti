using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioCivisNavmesh : OrdinatioCivis, IOrdinatioCivisNavmesh {
        private Vector3 _positio;
        private bool _estTransporto;
        private float _velocitasDesiderata;
        private float _acceleratio;
        private int _velocitasRotationis;
        private float _distantiaDeaccelerationis;

        public OrdinatioCivisNavmesh(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.ActioNavmesh) {
            _positio = default;
            _estTransporto = false;
            _velocitasDesiderata = 0f;
            _acceleratio = 0f;
            _velocitasRotationis = 0;
            _distantiaDeaccelerationis = 0f;
        }

        public Vector3 Positio => _positio;
        public bool EstTransporto => _estTransporto;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public int VelocitasRotationis => _velocitasRotationis;
        public float DistantiaDeaccelerationis => _distantiaDeaccelerationis;

        public override void Purgere() {
            _estApplicandum = false;

            _positio = default;
            _estTransporto = false;
            _velocitasDesiderata = 0f;
            _acceleratio = 0f;
            _velocitasRotationis = 0;
            _distantiaDeaccelerationis = 0f;
        }
        
        public void Pono(
            Vector3 positio,
            bool estTransporto,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ) {
            _estApplicandum = true;

            _positio = positio;
            _estTransporto = estTransporto;
            _velocitasDesiderata = velocitasDesiderata;
            _acceleratio = accelerationem;
            _velocitasRotationis = velocitasRotationis;
            _distantiaDeaccelerationis = distantiaDeaccelerationis;
        }
    }
}