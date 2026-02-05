using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeOssisMutabile : IOstiumPuellaeOssisMutabile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        public OstiumPuellaeOssisMutabile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                Errorum.Fatal(IDErrorum.OSSTIUMPUELLAEOSSISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeOssis = miPuellaeOssis;
        }

        public void PonoPositionem(IDPuellaeOssis idOssis, System.Numerics.Vector3 positio) {
            _miPuellaeOssis.PonoPositionem(idOssis, InterpressNumericus.ToUnity(positio));
        }
        public void PonoRotationem(IDPuellaeOssis idOssis, System.Numerics.Quaternion rotatio) {
            _miPuellaeOssis.PonoRotationem(idOssis, InterpressNumericus.ToUnity(rotatio));
        }
        public void PonoScalam(IDPuellaeOssis idOssis, System.Numerics.Vector3 scala) {
            _miPuellaeOssis.PonoScalam(idOssis, InterpressNumericus.ToUnity(scala));
        }
    }
}


