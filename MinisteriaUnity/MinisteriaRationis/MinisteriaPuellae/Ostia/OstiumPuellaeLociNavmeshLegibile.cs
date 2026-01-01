using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeLociNavmeshLegibile : IOstiumPuellaeLociNavmeshLegibile {
        private readonly MinisteriumPuellaeLociNavmesh _miPuellaeLociNavmesh;

        public OstiumPuellaeLociNavmeshLegibile(MinisteriumPuellaeLociNavmesh miPuellaeLociNavmesh) {
            if (miPuellaeLociNavmesh == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAELOCINAVMESHLEGIBILE_INSTANCE_NULL);
            }
            _miPuellaeLociNavmesh = miPuellaeLociNavmesh;
        }

        public bool EstActivum() => _miPuellaeLociNavmesh.EstActivum;
        public bool EstAdPerveni() => _miPuellaeLociNavmesh.EstAdPerveni();
        public float VelocitasHorizontalisActualis() => _miPuellaeLociNavmesh.VelocitasHorizontalisActualis();
        public float VelocitasVerticalisActualis() => _miPuellaeLociNavmesh.VelocitasVerticalisActualis();
        public float RotatioYActualis() => _miPuellaeLociNavmesh.RotatioYActualis();
        public float LegoVelocitatem() => _miPuellaeLociNavmesh.LegoVelocitatem();
        public float LegoAccelerationem() => _miPuellaeLociNavmesh.LegoAccelerationem();
        public float LegoDistantiaDeaccelerationis() => _miPuellaeLociNavmesh.LegoDistantiaDeaccelerationis();
        public int LegoVelocitatemRotationisDeg() => (int)_miPuellaeLociNavmesh.LegoVelocitatemRotationisDeg();
        public Vector3 Positio() => InterpressNumericus.ToNumerics(_miPuellaeLociNavmesh.Positio());
        public Quaternion Rotatio() => InterpressNumericus.ToNumerics(_miPuellaeLociNavmesh.Rotatio());
    }
}

