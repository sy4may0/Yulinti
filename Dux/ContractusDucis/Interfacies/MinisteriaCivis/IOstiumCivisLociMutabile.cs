namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        void ActivareMotus(int id);
        bool ActivareNavMesh(int id);
        bool Transporto(int id, System.Numerics.Vector3 positio, System.Numerics.Quaternion rotatio);
        void InitareMigrare(int id);
        void IncipereMigrare(int id, System.Numerics.Vector3 positio);
        void PonoVelocitatem(int id, float velocitatem);
        void PonoAccelerationem(int id, float accelerationem);
        void PonoVelocitatemRotationis(int id, int velocitatemRotationisDeg);
        void PonoDistantiaDeaccelerationis(int id, float distantiaDeaccelerationis);
        void Moto(
            int id,
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        );
    }
}
