namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaCivisVeletudinisLegibile {
        int Longitudo { get; }
        int Vitae(int idCivis);
        bool EstDominare(int idCivis);
        bool EstExhaurita(int idCivis);
    }
}