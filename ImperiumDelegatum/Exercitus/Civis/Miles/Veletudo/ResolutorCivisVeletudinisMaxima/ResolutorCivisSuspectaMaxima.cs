using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisSuspectaMaxima : IResolutorCivisSuspectaMaxima {
        public float Resolvere() {
            return CivisVeletudinis.SuspectaMaximaBasis;
        }
    }
}
