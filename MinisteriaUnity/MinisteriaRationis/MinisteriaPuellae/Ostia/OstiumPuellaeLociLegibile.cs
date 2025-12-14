using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeLociLegibile : IOstiumPuellaeLociLegibile {
        private readonly MinisteriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociLegibile(MinisteriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAELOCILEGIBILE_INSTANCE_NULL);
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


