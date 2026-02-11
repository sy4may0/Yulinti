using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Unity.Instrumentarium;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeLociLegibile : IOstiumPuellaeLociLegibile {
        private readonly MinisteriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociLegibile(MinisteriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeLociLegibile_OSTIUMPUELLAELOCILEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeLoci = miPuellaeLoci;
        }

        public bool EstActivum() => _miPuellaeLoci.EstActivum();
        public bool EstErrans() => _miPuellaeLoci.EstErrans();
        public bool EstActivumMotus() => _miPuellaeLoci.EstActivumMotus();
        public bool EstActivumNavMesh() => _miPuellaeLoci.EstActivumNavMesh();
        public bool EstAdPerveni() => _miPuellaeLoci.EstAdPerveni();
        public bool EstMigrare() => _miPuellaeLoci.EstMigrare();
        public float VelocitasHorizontalisActualis() => _miPuellaeLoci.VelocitasHorizontalisActualis();
        public float RotatioYActualis() => _miPuellaeLoci.RotatioYActualis();
        public System.Numerics.Vector3 Positio() => InterpressNumericus.ToNumerics(_miPuellaeLoci.Positio());
        public System.Numerics.Quaternion Rotatio() => InterpressNumericus.ToNumerics(_miPuellaeLoci.Rotatio());
    }
}

