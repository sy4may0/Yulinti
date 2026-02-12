using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    public static class FaberDucisIndexusPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            // Legatus
            builder.Register<ILegatusIndexusPrincipalis, LegatusIndexusPrincipalis>(Lifetime.Singleton);
        }
    }
}