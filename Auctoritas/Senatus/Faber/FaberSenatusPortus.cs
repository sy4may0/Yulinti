using VContainer;
using VContainer.Unity;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public static class FaberSenatusPortus {
        public static void Initio(IContainerBuilder builder) {
            // Curator
            builder.Register<CuratorVela>(Lifetime.Singleton);

            // Portus
            builder.Register<PraecoPortus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Senator
            builder.Register<ISenator, Senator>(Lifetime.Singleton);
        }
    }
}