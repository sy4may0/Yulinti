using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeLociNavmeshMutabile : IOstiumPuellaeLociNavmeshMutabile {
        private readonly MinisteriumPuellaeLociNavmesh _miPuellaeLociNavmesh;

        public OstiumPuellaeLociNavmeshMutabile(MinisteriumPuellaeLociNavmesh miPuellaeLociNavmesh) {
            if (miPuellaeLociNavmesh == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAELOCINAVMESHMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeLociNavmesh = miPuellaeLociNavmesh;
        }

        public void Activare() => _miPuellaeLociNavmesh.Activare();
        public void Deactivare() => _miPuellaeLociNavmesh.Deactivare();
        public void Transporto(Vector3 positio, Quaternion rotatio) => _miPuellaeLociNavmesh.Transporto(
            InterpressNumericus.ToUnity(positio), InterpressNumericus.ToUnity(rotatio)
        );
        public void IncipereMigrare(Vector3 positio) => _miPuellaeLociNavmesh.IncipereMigrare(InterpressNumericus.ToUnity(positio));
        public void PonoVelocitatem(float velocitatem) => _miPuellaeLociNavmesh.PonoVelocitatem(velocitatem);
        public void PonoAccelerationem(float accelerationem) => _miPuellaeLociNavmesh.PonoAccelerationem(accelerationem);
        public void PonoVelocitatemRotationis(int velocitatemRotationisDeg) => _miPuellaeLociNavmesh.PonoVelocitatemRotationis(velocitatemRotationisDeg);
        public void PonoDistantiaDeaccelerationis(float distantiaDeaccelerationis) => _miPuellaeLociNavmesh.PonoDistantiaDeaccelerationis(distantiaDeaccelerationis);
        public void TerminareMigrare() => _miPuellaeLociNavmesh.TerminareMigrare();
    }
}

