using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    public static class FaberMinisteriaIndexPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            // CancellationTokenSource
            builder.Register<SignumCancellationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<MinisteriumSignumCancellationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<IOstiumSignumCancellationisLegibile, OstiumSignumCancellationisLegibile>(Lifetime.Singleton);

            // Temporis
            builder.Register<FonsTemporis>(Lifetime.Singleton);
            builder.Register<ITemporis, Temporis>(Lifetime.Singleton);

            // Nuclei
            builder.Register<IOstiumTemporisLegibile, OstiumTemporisLegibile>(Lifetime.Singleton);

            // Ministeria
            builder.Register<IMinisteria, Ministeria>(Lifetime.Singleton);
        }
    }
}