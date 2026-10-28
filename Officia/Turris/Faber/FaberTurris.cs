using VContainer;
using VContainer.Unity;
using System;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    public static class FaberTurris {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<SignumCancellationisRadcis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<TurrisSignumCancellationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TurrisMundus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<TurrisIntroductionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TurrisInterpretationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TabulaPhantasma>(Lifetime.Singleton);
            builder.Register<TurrisSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TurrisCorrectrix>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<ResolutorPuellaePersonae>(Lifetime.Singleton);
            builder.Register<PhantasmaPuellaePersonae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<TurrisPhantasmaPuellaePersonae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PhantasmaPuellaeFormarum>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<TurrisPhantasmaPuellaeFormarum>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PhantasmaPuellaeCrinis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<TurrisPhantasmaPuellaeCrinis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TurrisSoniVeli>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // 共通Randomソース
            builder.RegisterInstance(new Random());

            builder.Register<IMonsAltus, MonsAltus>(Lifetime.Singleton);
        }
    }
}