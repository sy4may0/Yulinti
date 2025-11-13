using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.Nucleus.InstrumentaMinisterii;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeOssisLegibile : IOstiumPuellaeOssisLegibile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;

        public OstiumPuellaeOssisLegibile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeOssisのインスタンスがnullです。");
            }
            _miPuellaeOssis = miPuellaeOssis;
        }

        public System.Numerics.Vector3 LegoPositionem(BoneID boneID) => 
            InterpressNumericus.ToNumerics(_miPuellaeOssis.LegoPositionem(boneID));
        public System.Numerics.Quaternion LegoRotationem(BoneID boneID) =>
            InterpressNumericus.ToNumerics(_miPuellaeOssis.LegoRotationem(boneID));
        public System.Numerics.Vector3 LegoScalam(BoneID boneID) =>
            InterpressNumericus.ToNumerics(_miPuellaeOssis.LegoScalam(boneID));
    }
}