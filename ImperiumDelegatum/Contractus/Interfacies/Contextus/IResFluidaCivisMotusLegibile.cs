namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaCivisMotusLegibile {
        int Longitudo { get; }
        float VelocitasActualisHorizontalis(int idCivis);
        float VelocitasActualisVerticalis(int idCivis);
        float RotatioYActualis(int idCivis);
        bool EstInTerra(int idCivis);
    }
}