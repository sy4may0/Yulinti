using VContainer;
using VContainer.Unity;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public static class FaberSenatusTestScene {
        public static void Initio(IContainerBuilder builder) {
            // Culator
            builder.Register<CuratorVela>(Lifetime.Singleton);

            // Operatio

            // Praeco
            // 未実装
            builder.Register<PraecoSpatiiPuellaeVeletudinis>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.Register<PraecoSpatiiCivisVeletudinis>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            // Senator
            builder.Register<ISenator, Senator>(Lifetime.Singleton);
        }
    }
}