namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaCivisVeletudinisLegibile {
        int Longitudo { get; }
        float Vitae(int idCivis);
        bool EstDominare(int idCivis);
        bool EstExhaurita(int idCivis);
        bool EstMotus(int idCivis);
    }
}