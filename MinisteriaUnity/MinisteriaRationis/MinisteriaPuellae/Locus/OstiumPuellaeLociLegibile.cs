using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeLociLegibile : IOstiumPuellaeLociLegibile {
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociLegibile(MiniateriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                ModeratorErrorum.Fatal("MiniateriumPuellaeLociのインスタンスがnullです。");
            }
            _miPuellaeLoci = miPuellaeLoci;
        }
        public float VelHorizontalisActualis => _miPuellaeLoci.VelHorizontalisActualis;
        public float VelVerticalisActualis => _miPuellaeLoci.VelVerticalisActualis;
        public float RotatioYActualis => _miPuellaeLoci.RotatioYActualis;
        public System.Numerics.Vector3 Positio => 
            InterpressNumericus.ToNumerics(_miPuellaeLoci.Positio);
        public System.Numerics.Quaternion Rotatio => 
            InterpressNumericus.ToNumerics(_miPuellaeLoci.Rotatio);
    }
}
