using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.Nucleus.InstrumentaMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeLociLegibile : IOstiumPuellaeLociLegibile {
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociLegibile(MiniateriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                ModeratorErrorum.Fatal("MiniateriumPuellaeLociのインスタンスがnullです。");
            }
            _miPuellaeLoci = miPuellaeLoci;
        }
        public float VelHorizontalisPre => _miPuellaeLoci.VelHorizontalisPre;
        public float VelVerticalisPre => _miPuellaeLoci.VelVerticalisPre;
        public float RotatioYPre => _miPuellaeLoci.RotatioYPre;
        public System.Numerics.Vector3 Positio => 
            InterpressNumericus.ToNumerics(_miPuellaeLoci.Positio);
        public System.Numerics.Quaternion Rotatio => 
            InterpressNumericus.ToNumerics(_miPuellaeLoci.Rotatio);
    }
}