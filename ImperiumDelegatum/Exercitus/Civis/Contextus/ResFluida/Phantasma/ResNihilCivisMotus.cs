using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResNihilCivisMotus : IResFluidaCivisMotusLegibile {
        public ResNihilCivisMotus() {
        }

        public int Longitudo => 0;
        public bool EstActivum(int idCivis) => false;
        public float VelocitasActualisHorizontalis(int idCivis) => 0f;
        public float VelocitasActualisVerticalis(int idCivis) => 0f;
        public float RotatioYActualis(int idCivis) => 0f;
        public bool EstInTerra(int idCivis) => false;
    }
}