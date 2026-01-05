namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaCivisVeletudinisLegibile {
        int Longitudo { get; }
        float Vitae(int idCivis);
        float Visus(int idCivis);
        float Visa(int idCivis);

        bool EstDominare(int idCivis);
        bool EstExhaurita(int idCivis);
        bool EstMotus(int idCivis);

        bool EstVigilantia(int idCivis);
        bool EstDetectio(int idCivis);

    }
}