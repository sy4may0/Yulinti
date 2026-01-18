namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaCivisVeletudinisLegibile {
        int Longitudo { get; }
        float Vitae(int idCivis);
        float Visus(int idCivis);
        float Visa(int idCivis);
        float Audita(int idCivis);
        float Suspecta(int idCivis);

        bool EstDominare(int idCivis);
        bool EstExhaurita(int idCivis);

        bool EstVigilantia(int idCivis);
        bool EstDetectio(int idCivis);

        bool EstSpectareNudusAnterior(int idCivis);
        bool EstSpectareNudusPosterior(int idCivis);
        bool EstSpectareNudus(int idCivis);
    }
}