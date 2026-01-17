namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeLociLegibile {
        bool EstActivum();
        bool EstErrans();
        bool EstActivumMotus();
        bool EstActivumNavMesh();
        bool EstAdPerveni();
        bool EstMigrare();
        float VelocitasHorizontalisActualis();
        float RotatioYActualis();
        System.Numerics.Vector3 Positio();
        System.Numerics.Quaternion Rotatio();
    }
}


