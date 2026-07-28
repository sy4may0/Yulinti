using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisStudiumMaxima : IResolutorCivisStudiumMaxima {
        public float Resolvere() {
            return CivisVeletudinis.StudiumMaximaBasis;
        }
    }
}
