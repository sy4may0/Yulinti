using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeLociMutabile : IOstiumPuellaeLociMutabile {
        private readonly MinisteriumPuellaeLoci _miPuellaeLoci;
        public OstiumPuellaeLociMutabile(MinisteriumPuellaeLoci miPuellaeLoci) {
            if (miPuellaeLoci == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAELOCIMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeLoci = miPuellaeLoci;
        }

        public bool EstActivum() => _miPuellaeLoci.EstActivum();
        public void ActivareMotus() => _miPuellaeLoci.ActivareMotus();
        public bool ActivareNavMesh() => _miPuellaeLoci.ActivareNavMesh();
        public bool Transporto(System.Numerics.Vector3 positio, System.Numerics.Quaternion rotatio) =>
            _miPuellaeLoci.Transporto(InterpressNumericus.ToUnity(positio), InterpressNumericus.ToUnity(rotatio));
        public void InitareMigrare() => _miPuellaeLoci.InitareMigrare();
        public void IncipereMigrare(System.Numerics.Vector3 positio) =>
            _miPuellaeLoci.IncipereMigrare(InterpressNumericus.ToUnity(positio));
        public void PonoVelocitatem(float velocitatem) => _miPuellaeLoci.PonoVelocitatem(velocitatem);
        public void PonoAccelerationem(float accelerationem) => _miPuellaeLoci.PonoAccelerationem(accelerationem);
        public void PonoVelocitatemRotationis(int velocitatemRotationisDeg) =>
            _miPuellaeLoci.PonoVelocitatemRotationis(velocitatemRotationisDeg);
        public void PonoDistantiaDeaccelerationis(float distantiaDeaccelerationis) =>
            _miPuellaeLoci.PonoDistantiaDeaccelerationis(distantiaDeaccelerationis);
        public void Moto(
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        ) {
            _miPuellaeLoci.Moto(
                velocitasHorizontalisDesiderata,
                tempusLevigatumHorizontalis,
                rotatioYDesiderata,
                tempusLevigatumRotatioY,
                intervallum
            );
        }
    }
}

