namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaCivisMotusLegibile {
        int Longitudo { get; }
        float VelocitasActualisHorizontalis(int idCivis);
        float VelocitasActualisVerticalis(int idCivis);
        float RotatioYActualis(int idCivis);
        bool EstInTerra(int idCivis);
    }
}