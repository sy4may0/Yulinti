using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.Nucleus.InstrumentaMinisterii;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeOssisMutabile : IOstiumPuellaeOssisMutabile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        public OstiumPuellaeOssisMutabile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeOssisのインスタンスがnullです。");
            }
            _miPuellaeOssis = miPuellaeOssis;
        }

        public void PonoPositionem(BoneID boneID, System.Numerics.Vector3 positio) {
            _miPuellaeOssis.PonoPositionem(boneID, InterpressNumericus.ToUnity(positio));
        }
        public void PonoRotationem(BoneID boneID, System.Numerics.Quaternion rotatio) {
            _miPuellaeOssis.PonoRotationem(boneID, InterpressNumericus.ToUnity(rotatio));
        }
        public void PonoScalam(BoneID boneID, System.Numerics.Vector3 scala) {
            _miPuellaeOssis.PonoScalam(boneID, InterpressNumericus.ToUnity(scala));
        }
    }
}