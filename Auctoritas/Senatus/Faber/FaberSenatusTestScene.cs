using VContainer;
using VContainer.Unity;
using Yulinti.Auctoritas.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public static class FaberSenatusTestScene {
        public static void Initio(IContainerBuilder builder) {
            // Culator
            builder.Register<CuratorVela>(Lifetime.Singleton);

            // Praeco
            // 未実装

            // Senator
            builder.Register<ISenator, Senator>(Lifetime.Singleton);
        }
    }
}