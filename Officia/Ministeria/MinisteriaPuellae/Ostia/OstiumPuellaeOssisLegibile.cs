using Yulinti.Officia.Ministeria;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeOssisLegibile : IOstiumPuellaeOssisLegibile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;

        public OstiumPuellaeOssisLegibile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeOssisLegibile_OSTIUMPUELLAEOSSISLEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeOssis = miPuellaeOssis;
        }

        public System.Numerics.Vector3 LegoPositionem(IDPuellaeOssis idOssis) => 
            InterpresNumeri.ToNumerics(_miPuellaeOssis.LegoPositionem(idOssis));
        public System.Numerics.Quaternion LegoRotationem(IDPuellaeOssis idOssis) =>
            InterpresNumeri.ToNumerics(_miPuellaeOssis.LegoRotationem(idOssis));
        public System.Numerics.Vector3 LegoScalam(IDPuellaeOssis idOssis) =>
            InterpresNumeri.ToNumerics(_miPuellaeOssis.LegoScalam(idOssis));
    }
}

