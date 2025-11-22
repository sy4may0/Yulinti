namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeLociMutabile {
        void PonoPositionemCoacte(System.Numerics.Vector3 positio);
        void PonoRotationemCoacte(System.Numerics.Quaternion rotatio);
        void Moto(
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