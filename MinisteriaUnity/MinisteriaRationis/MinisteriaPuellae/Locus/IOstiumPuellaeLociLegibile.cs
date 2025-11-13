namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeLociLegibile {
        float VelHorizontalisPre { get; }
        float VelVerticalisPre { get; }
        float RotatioYPre { get; }
        System.Numerics.Vector3 Positio { get; }
        System.Numerics.Quaternion Rotatio { get; }
    }
}