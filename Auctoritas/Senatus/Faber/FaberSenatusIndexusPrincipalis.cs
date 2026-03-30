using VContainer;
using VContainer.Unity;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public static class FaberSenatusIndexusPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            // Culator
            builder.Register<CuratorVela>(Lifetime.Singleton);

            // Operatio
            builder.Register<OperatioIndexusPrincipalis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // IndexusPrincipalis
            builder.Register<PraecoIndexusPrincipalis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Salsamenti
            builder.Register<PraecoSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            //Senator
            builder.Register<ISenator, Senator>(Lifetime.Singleton);
        }
    }
}