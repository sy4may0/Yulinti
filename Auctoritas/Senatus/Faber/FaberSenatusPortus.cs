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
            builder.Register<OperatioPortusConstructionisLapsorCorporis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioPortusConstructionisLapsorFaciei>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioPortusConstructionisSubligaculi>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioPortusConstructionisTunicae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioPortusConstructionisOrnamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<OperatioPortusConstructionisSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Praeco
            builder.Register<PraecoPortus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionisLapsorCorporis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionisLapsorFaciei>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionisSubligaculi>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionisTunicae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionisOrnamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PraecoPortusConstructionisSalsamenti>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Senator
            builder.Register<ISenator, Senator>(Lifetime.Singleton);
        }
    }
}