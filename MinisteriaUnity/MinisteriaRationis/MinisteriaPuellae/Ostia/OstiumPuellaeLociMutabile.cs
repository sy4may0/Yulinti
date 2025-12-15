using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeLociMutabile : IOstiumPuellaeLociMutabile {
        private readonly MinisteriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociMutabile(MinisteriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAELOCIMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeLoci = miPuellaeLoci;
        }

        public void PonoPositionemCoacte(System.Numerics.Vector3 positio) {
            _miPuellaeLoci.PonoPositionemCoacte(InterpressNumericus.ToUnity(positio));
        }
        public void PonoRotationemCoacte(System.Numerics.Quaternion rotatio) {
            _miPuellaeLoci.PonoRotationemCoacte(InterpressNumericus.ToUnity(rotatio));
        }
        public void Moto(
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float velocitasVerticalisDesiderata,
            float tempusLevigatumVerticalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        ) {
            _miPuellaeLoci.Moto(
                velocitasHorizontalisDesiderata,
                tempusLevigatumHorizontalis,
                velocitasVerticalisDesiderata,
                tempusLevigatumVerticalis,
                rotatioYDesiderata,
                tempusLevigatumRotatioY,
                intervallum
            );
        }
    }
}


