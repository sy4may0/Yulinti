namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociLegibile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        float VelHorizontalisActualis(int id);
        float VelVerticalisActualis(int id);
        float RotatioYActualis(int id);
        System.Numerics.Vector3 Positio(int id);
        System.Numerics.Quaternion Rotatio(int id);
    }
}