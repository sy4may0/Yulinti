using Yulinti.MinisteriaUnity.Interna;
using Yulinti.Nucleus.InstrumentaMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeLociMutabile : IOstiumPuellaeLociMutabile {
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociMutabile(MiniateriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                ModeratorErrorum.Fatal("MiniateriumPuellaeLociのインスタンスがnullです。");
            }
            _miPuellaeLoci = miPuellaeLoci;
        }

        public void PonoPositionemCoacte(System.Numerics.Vector3 positio) {
            _miPuellaeLoci.PonoPositionemCoacte(InterpressNumericus.ToUnity(positio));
        }
        public void PonoRotationemCoacte(System.Numerics.Quaternion rotatio) {
            _miPuellaeLoci.PonoRotationemCoacte(InterpressNumericus.ToUnity(rotatio));
        }
        public void AddoVelocitatemHorizontalisLate(float velocitasMeta, float tempusLevis, float intervallum) {
            _miPuellaeLoci.AddoVelocitatemHorizontalisLate(velocitasMeta, tempusLevis, intervallum);
        }
        public void AddoVelocitatemVerticalisLate(float velocitasMeta, float tempusLevis, float intervallum) {
            _miPuellaeLoci.AddoVelocitatemVerticalisLate(velocitasMeta, tempusLevis, intervallum);
        }
        public void PonoRotationisYLate(float rotatioYMeta, float tempusLevis, float intervallum) {
            _miPuellaeLoci.PonoRotationisYLate(rotatioYMeta, tempusLevis, intervallum);
        }
    }
}