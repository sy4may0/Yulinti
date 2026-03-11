using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    public static class FaberDucisIndexusPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            // Legatus
            builder.Register<ILegatus, Legatus>(Lifetime.Singleton);
        }
    }
}