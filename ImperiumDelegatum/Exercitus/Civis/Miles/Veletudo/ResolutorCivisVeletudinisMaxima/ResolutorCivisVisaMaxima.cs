using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisVisaMaxima : IResolutorCivisVisaMaxima {
        public float Resolvere() {
            return CivisVeletudinis.VisaMaximaBasis;
        }
    }
}
