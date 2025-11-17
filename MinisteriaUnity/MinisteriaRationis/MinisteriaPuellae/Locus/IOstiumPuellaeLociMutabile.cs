namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeLociMutabile {
        void PonoPositionemCoacte(System.Numerics.Vector3 positio);
        void PonoRotationemCoacte(System.Numerics.Quaternion rotatio);
        void AddoVelocitatemHorizontalisLate(float velocitasMeta, float tempusLevis, float intervallum);
        void AddoVelocitatemVerticalisLate(float velocitasMeta, float tempusLevis, float intervallum);
        void PonoRotationisYLate(float rotatioYMeta, float tempusLevis, float intervallum);
    }
}