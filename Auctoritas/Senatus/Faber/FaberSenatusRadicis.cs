using VContainer;
using VContainer.Unity;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public static class FaberSenatusRadicis {
        public static void Initio(IContainerBuilder builder) {
            // Radixは閉じないので、CuratorVelaは不要。
            // Confirmatio, Monitionis
            builder.Register<PraecoConfirmationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoMonitionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<ISenatorRadicis, SenatorRadicis>(Lifetime.Singleton);
        }
    }
}