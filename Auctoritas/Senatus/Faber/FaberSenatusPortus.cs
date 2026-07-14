using VContainer;
using VContainer.Unity;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public static class FaberSenatusPortus {
        public static void Initio(IContainerBuilder builder) {
            // Curator
            builder.Register<CuratorVela>(Lifetime.Singleton);

            // Operatio
            builder.Register<OperatioPortus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioPortusConstructionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Praeco
            builder.Register<PraecoPortus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Senator
            builder.Register<ISenator, Senator>(Lifetime.Singleton);
        }
    }
}