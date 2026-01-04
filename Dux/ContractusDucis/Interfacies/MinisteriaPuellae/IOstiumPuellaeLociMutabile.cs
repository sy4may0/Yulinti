namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeLociMutabile {
        bool EstActivum();
        void ActivareMotus();
        bool ActivareNavMesh();
        bool Transporto(System.Numerics.Vector3 positio, System.Numerics.Quaternion rotatio);
        void InitareMigrare();
        void IncipereMigrare(System.Numerics.Vector3 positio);
        void PonoVelocitatem(float velocitatem);
        void PonoAccelerationem(float accelerationem);
        void PonoVelocitatemRotationis(int velocitatemRotationisDeg);
        void PonoDistantiaDeaccelerationis(float distantiaDeaccelerationis);
        void Moto(
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        );
    }
}


