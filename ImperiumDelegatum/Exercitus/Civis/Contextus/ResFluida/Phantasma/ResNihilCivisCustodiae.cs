using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisCustodiae : IResFluidaCivisCustodiaeLegibile {
        public ResNihilCivisCustodiae() {
        }
        public int Longitudo => 0;
        public bool EstActivum(int idCivis) => false;
        public float VisaCapitis(int idCivis) => 0f;
        public float VisaCorporis(int idCivis) => 0f;
        public float RatioVisae(int idCivis) => 0f;
        public bool EstVisaCapitis(int idCivis) => false;
        public bool EstVisaCorporis(int idCivis) => false;
        public bool EstVisa(int idCivis) => false;
        public float RatioAudita(int idCivis) => 0f;
        public bool EstAudita(int idCivis) => false;
        public float DistantiaPuellae(int idCivis) => float.MaxValue;
        public bool EstCustodiaeVisae(int idCivis) => false;
        public bool EstCustodiaeAuditae(int idCivis) => false;
    }
}