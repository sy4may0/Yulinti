using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisCustodiae : IResFluidaCivisCustodiaeLegibile {
        public ResNihilCivisCustodiae() {
        }
        public int Longitudo => 0;
        public float VisaCapitis(int idCivis) => 0f;
        public float VisaCorporis(int idCivis) => 0f;
        public float RatioVisus(int idCivis) => 0f;
        public bool EstVisa(int idCivis) => false;
        public float Audita(int idCivis) => 0f;
        public bool EstAudita(int idCivis) => false;
        public float DistantiaPuellae(int idCivis) => float.MaxValue;
        public bool EstCustodiaeVisae(int idCivis) => false;
        public bool EstCustodiaeAuditae(int idCivis) => false;
    }
}