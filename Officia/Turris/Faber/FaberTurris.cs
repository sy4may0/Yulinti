using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    public static class FaberTurris {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<ITurrisMundus, TurrisMundus>(Lifetime.Singleton);
            builder.Register<ITurrisIntroductionis, TurrisIntroductionis>(Lifetime.Singleton);
            builder.Register<ITurrisInterpretationis, TurrisInterpretationis>(Lifetime.Singleton);
            builder.Register<TurrisSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<TurrisPhantasmaPuellaePersonae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<TurrisSoniVeli>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<IMonsAltus, MonsAltus>(Lifetime.Singleton);
        }
    }
}