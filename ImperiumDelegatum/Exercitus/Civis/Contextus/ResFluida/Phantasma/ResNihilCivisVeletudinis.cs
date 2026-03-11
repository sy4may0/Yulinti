using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        public ResNihilCivisVeletudinis() {
        }
        public int Longitudo => 0;
        public float Vitae(int idCivis) => 0f;
        public float Visus(int idCivis) => 0f;
        public float Visa(int idCivis) => 0f;
        public float Auditus(int idCivis) => 0f;
        public float Audita(int idCivis) => 0f;
        public float Suspecta(int idCivis) => 0f;
        public bool EstDominare(int idCivis) => false;
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