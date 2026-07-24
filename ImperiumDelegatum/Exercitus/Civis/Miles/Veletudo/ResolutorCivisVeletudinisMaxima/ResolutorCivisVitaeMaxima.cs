using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisVitaeMaxima : IResolutorCivisVitaeMaxima {
        public float Resolvere() {
            return CivisVeletudinis.VitaeMaximaBasis;
        }
    }
}
