using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Unity.Instrumentarium;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeOssisMutabile : IOstiumPuellaeOssisMutabile {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        public OstiumPuellaeOssisMutabile(MinisteriumPuellaeOssis miPuellaeOssis) {
            if (miPuellaeOssis == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeOssisMutabile_OSSTIUMPUELLAEOSSISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeOssis = miPuellaeOssis;
        }

        public void PonoPositionem(IDPuellaeOssis idOssis, System.Numerics.Vector3 positio) {
            _miPuellaeOssis.PonoPositionem(idOssis, InterpresNumeri.ToUnity(positio));
        }
        public void PonoRotationem(IDPuellaeOssis idOssis, System.Numerics.Quaternion rotatio) {
            _miPuellaeOssis.PonoRotationem(idOssis, InterpresNumeri.ToUnity(rotatio));
        }
        public void PonoScalam(IDPuellaeOssis idOssis, System.Numerics.Vector3 scala) {
            _miPuellaeOssis.PonoScalam(idOssis, InterpresNumeri.ToUnity(scala));
        }
    }
}

