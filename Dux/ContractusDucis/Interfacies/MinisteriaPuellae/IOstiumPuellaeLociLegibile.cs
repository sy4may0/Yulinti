namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeLociLegibile {
        bool EstActivum { get; }
        float VelHorizontalisActualis { get; }
        float VelVerticalisActualis { get; }
        float RotatioYActualis { get; }
        System.Numerics.Vector3 Positio { get; }
        System.Numerics.Quaternion Rotatio { get; }
    }
}


