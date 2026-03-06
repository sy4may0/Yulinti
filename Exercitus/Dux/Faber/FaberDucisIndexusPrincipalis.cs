using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    public static class FaberDucisIndexusPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            // Legatus
            builder.Register<LegatusIndexusPrincipalis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<LegatusSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<CuratorVela>(Lifetime.Singleton);

            // DuxExercitus
            builder.Register<IDuxExercitus, DuxExercitus>(Lifetime.Singleton);
        }
    }
}