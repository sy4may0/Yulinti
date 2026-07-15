using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    public static class FaberDucisPortus {
        public static void Initio(IContainerBuilder builder) {
            // ContextusResFluida
            builder.Register<ResFluidaPuellaeMotus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResFluidaPuellaeVeletudinis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResFluidaPuellaeSpectaculi>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResFluidaPuellaeFormae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<ResFluidaPuellaeLegibile>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // ContextusSalsamenti
            builder.Register<IContextusSalsamenti, ContextusSalsamenti>(Lifetime.Singleton);
            

            // Civis
            // このシーンにCivisは存在しないため、長さ0のCivisリストとなるのダミーを登録する。
            // 一応値は取れるので注意。
            builder.Register<ResNihilCivisMotus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResNihilCivisVeletudinis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResNihilCivisLegibile>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Carrus
            builder.Register<CarrusPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            
            // Scrinium
            builder.Register<ScriniumPuellaeFormae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Contextus
            builder.Register<ContextusRamusPuellae>(Lifetime.Singleton);
            builder.Register<ContextusStatusPuellaeCorporis>(Lifetime.Singleton);

            // Executor
            builder.Register<ExecutorPuellaeAnimationis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeLoci>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeVeletudinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaePersonae>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeFormae>(Lifetime.Singleton);

            builder.Register<IResolutorPuellaeVigorisMaxima, ResolutorPuellaeVigorisMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaePatientiaeMaxima, ResolutorPuellaePatientiaeMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeClaritatisMaximus, ResolutorPuellaeClaritatisMaximus>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeAnomaliaeMaxima, ResolutorPuellaeAnomaliaeMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeAetherisMaxima, ResolutorPuellaeAetherisMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeIntentioMaxima, ResolutorPuellaeIntentioMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeDedecorisMaximum, ResolutorPuellaeDedecorisMaximum>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeSonusQuietesMaximus, ResolutorPuellaeSonusQuietesMaximus>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeSonusMotusMaximus, ResolutorPuellaeSonusMotusMaximus>(Lifetime.Singleton);

            // Miles
            builder.Register<MilesPuellaeActionis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVestitae>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVigoris>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVeletudinisMaxima>(Lifetime.Singleton);

            // Centurio
            builder.Register<CenturioPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Legatus
            builder.Register<ILegatus, Legatus>(Lifetime.Singleton);
        }
    }
}
