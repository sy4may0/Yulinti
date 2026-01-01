namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        void Activare(int id);
        void Deactivare(int id);
        void PonoPositionemCoacte(int id, System.Numerics.Vector3 positio);
        void PonoRotationemCoacte(int id, System.Numerics.Quaternion rotatio);
        void Moto(
            int id,
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float velocitasVerticalisDesiderata,
            float tempusLevigatumVerticalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        );
    }
}