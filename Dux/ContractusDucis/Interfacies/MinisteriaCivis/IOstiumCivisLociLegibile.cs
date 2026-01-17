namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLociLegibile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        bool EstErrans(int id);
        bool EstActivumMotus(int id);
        bool EstActivumNavMesh(int id);
        bool EstAdPerveni(int id);
        bool EstMigrare(int id);
        float VelocitasHorizontalisActualis(int id);
        float RotatioYActualis(int id);
        System.Numerics.Vector3 Positio(int id);
        System.Numerics.Quaternion Rotatio(int id);
    }
}
