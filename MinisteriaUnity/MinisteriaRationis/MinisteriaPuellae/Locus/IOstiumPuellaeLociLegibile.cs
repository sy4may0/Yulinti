namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeLociLegibile {
        float VelHorizontalisActualis { get; }
        float VelVerticalisActualis { get; }
        float RotatioYActualis { get; }
        System.Numerics.Vector3 Positio { get; }
        System.Numerics.Quaternion Rotatio { get; }
    }
}


