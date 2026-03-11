using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.Officia.Ministeria {
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
        public System.Numerics.Vector3 Positio() => InterpresNumeri.ToNumerics(_miPuellaeLoci.Positio());
        public System.Numerics.Quaternion Rotatio() => InterpresNumeri.ToNumerics(_miPuellaeLoci.Rotatio());
    }
}
