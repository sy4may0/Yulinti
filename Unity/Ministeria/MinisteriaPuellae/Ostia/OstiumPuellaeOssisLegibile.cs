using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeOssisLegibile : IOstiumPuellaeOssisLegibile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;

        public OstiumPuellaeOssisLegibile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeOssisLegibile_OSTIUMPUELLAEOSSISLEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeOssis = miPuellaeOssis;
        }

        public System.Numerics.Vector3 LegoPositionem(IDPuellaeOssis idOssis) => 
            InterpressNumericus.ToNumerics(_miPuellaeOssis.LegoPositionem(idOssis));
        public System.Numerics.Quaternion LegoRotationem(IDPuellaeOssis idOssis) =>
            InterpressNumericus.ToNumerics(_miPuellaeOssis.LegoRotationem(idOssis));
        public System.Numerics.Vector3 LegoScalam(IDPuellaeOssis idOssis) =>
            InterpressNumericus.ToNumerics(_miPuellaeOssis.LegoScalam(idOssis));
    }
}


