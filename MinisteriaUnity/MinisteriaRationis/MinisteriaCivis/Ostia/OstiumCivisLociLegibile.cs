using System.Numerics;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLociLegibile : IOstiumCivisLociLegibile {
        private readonly MinisteriumCivisLoci _miCivisLoci;

        public OstiumCivisLociLegibile(MinisteriumCivisLoci miCivisLoci) {
            _miCivisLoci = miCivisLoci;
        }

        public bool EstActivum => _miCivisLoci.EstActivum;
        public bool EstAdPerveni => _miCivisLoci.EstAdPerveni;
        public float VelocitasHorizontalisActualis => _miCivisLoci.VelocitasHorizontalisActualis;
        public float VelocitasVerticalisActualis => _miCivisLoci.VelocitasVerticalisActualis;
        public float RotatioYActualis => _miCivisLoci.RotatioYActualis;
        public Vector3 Positio => InterpressNumericus.ToNumerics(_miCivisLoci.Positio);
        public Quaternion Rotatio => InterpressNumericus.ToNumerics(_miCivisLoci.Rotatio);
    }
}