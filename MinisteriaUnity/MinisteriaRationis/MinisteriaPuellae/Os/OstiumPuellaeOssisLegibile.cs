using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeOssisLegibile : IOstiumPuellaeOssisLegibile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;

        public OstiumPuellaeOssisLegibile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeOssisのインスタンスがnullです。");
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
