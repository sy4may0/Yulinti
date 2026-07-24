namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaCivisVeletudinisLegibile {
        int Longitudo { get; }

        float VitaeMaxima(int idCivis);
        float VisusMaxima(int idCivis);
        float AuditusMaxima(int idCivis);
        float SuspectaMaxima(int idCivis);
        float StudiumMaxima(int idCivis);
        float IntentioMaxima(int idCivis);
        float TorelantiaAnomaliaeMaximaMaxima(int idCivis);
        float TorelantiaAnomaliaeMinimaMaxima(int idCivis);

        IDCivisStatusCustodiae StatusCustodiaeCurrens(int idCivis);

        float Vitae(int idCivis);
        float Visus(int idCivis);
        float Auditus(int idCivis);
        float Suspecta(int idCivis);
        float Studium(int idCivis);
        float Intentio(int idCivis);
        float TorelantiaAnomaliaeMaxima(int idCivis);
        float TorelantiaAnomaliaeMinima(int idCivis);

        float RatioVitae(int idCivis);
        float RatioVisus(int idCivis);
        float RatioAuditus(int idCivis);
        float RatioSuspecta(int idCivis);
        float RatioStudium(int idCivis);
        float RatioIntentionis(int idCivis);
        float RatioTorelantiaAnomaliaeMaxima(int idCivis);
        float RatioTorelantiaAnomaliaeMinima(int idCivis);

        bool EstExhaurita(int idCivis);

        bool EstVigilantia(int idCivis);

        bool EstSpectareNudusAnterior(int idCivis);
        bool EstSpectareNudusPosterior(int idCivis);
        bool EstSpectareNudus(int idCivis);
    }
}
