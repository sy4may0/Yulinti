using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        public ResNihilCivisVeletudinis() {
        }
        public int Longitudo => 0;
        public float VitaeMaxima(int idCivis) => 0f;
        public float VisusMaxima(int idCivis) => 0f;
        public float VisaMaxima(int idCivis) => 0f;
        public float AuditusMaxima(int idCivis) => 0f;
        public float AuditaMaxima(int idCivis) => 0f;
        public float SuspectaMaxima(int idCivis) => 0f;
        public float StudiumMaxima(int idCivis) => 0f;
        public float IntentioMaxima(int idCivis) => 0f;
        public float TorelantiaAnomaliaeMaximaMaxima(int idCivis) => 0f;
        public float TorelantiaAnomaliaeMinimaMaxima(int idCivis) => 0f;
        public IDCivisStatusCustodiae StatusCustodiaeCurrens(int idCivis) => IDCivisStatusCustodiae.Circumitus;
        public float Vitae(int idCivis) => 0f;
        public float Visus(int idCivis) => 0f;
        public float Visa(int idCivis) => 0f;
        public float Auditus(int idCivis) => 0f;
        public float Audita(int idCivis) => 0f;
        public float Suspecta(int idCivis) => 0f;
        public float Studium(int idCivis) => 0f;
        public float Intentio(int idCivis) => 0f;
        public float TorelantiaAnomaliaeMaxima(int idCivis) => 0f;
        public float TorelantiaAnomaliaeMinima(int idCivis) => 0f;
        public float RatioVitae(int idCivis) => 0f;
        public float RatioVisus(int idCivis) => 0f;
        public float RatioVisa(int idCivis) => 0f;
        public float RatioAuditus(int idCivis) => 0f;
        public float RatioAudita(int idCivis) => 0f;
        public float RatioSuspecta(int idCivis) => 0f;
        public float RatioStudium(int idCivis) => 0f;
        public float RatioIntentionis(int idCivis) => 0f;
        public float RatioTorelantiaAnomaliaeMaxima(int idCivis) => 0f;
        public float RatioTorelantiaAnomaliaeMinima(int idCivis) => 0f;
        public bool EstExhaurita(int idCivis) => false;
        public bool EstVigilantia(int idCivis) => false;
        public bool EstDetectio(int idCivis) => false;
        public bool EstDetectioSonora(int idCivis) => false;
        public bool EstSuspecta(int idCivis) => false;
        public bool EstSpectareNudusAnterior(int idCivis) => false;
        public bool EstSpectareNudusPosterior(int idCivis) => false;
        public bool EstSpectareNudus(int idCivis) => false;
    }
}
