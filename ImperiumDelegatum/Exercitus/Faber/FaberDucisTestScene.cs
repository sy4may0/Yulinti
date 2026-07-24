using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    public static class FaberDucisTestScene {
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

            builder.Register<ResFluidaCivisMotus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResFluidaCivisVeletudinis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResFluidaCivisCustodiae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<ResFluidaCivisLegibile>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // ContextusSalsamenti
            builder.Register<IContextusSalsamenti, ContextusSalsamenti>(Lifetime.Singleton);

            // Carrus
            builder.Register<CarrusPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<CarrusCivis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Contextus
            builder.Register<ContextusRamusPuellae>(Lifetime.Singleton);
            builder.Register<ContextusStatusPuellaeCorporis>(Lifetime.Singleton);

            builder.Register<ContextusRamusCivis>(Lifetime.Singleton);
            builder.Register<ContextusStatusCivisCorporis>(Lifetime.Singleton);

            // Executor
            builder.Register<ExecutorPuellaeAnimationis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeLoci>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeVeletudinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaePersonae>(Lifetime.Singleton);

            builder.Register<ExecutorCivisAnimationis>(Lifetime.Singleton);
            builder.Register<ExecutorCivisLoci>(Lifetime.Singleton);
            builder.Register<ExecutorCivisMortis>(Lifetime.Singleton);
            builder.Register<ExecutorCivisVeletudinis>(Lifetime.Singleton);
            builder.Register<ExecutorCivisCustodiae>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeFormae>(Lifetime.Singleton);

            // Resolutor
            builder.Register<IResolutorPuellaeVigorisMaxima, ResolutorPuellaeVigorisMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaePatientiaeMaxima, ResolutorPuellaePatientiaeMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeClaritatisMaximus, ResolutorPuellaeClaritatisMaximus>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeAnomaliaeMaxima, ResolutorPuellaeAnomaliaeMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeAetherisMaxima, ResolutorPuellaeAetherisMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeIntentioMaxima, ResolutorPuellaeIntentioMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeDedecorisMaximum, ResolutorPuellaeDedecorisMaximum>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeSonusQuietesMaximus, ResolutorPuellaeSonusQuietesMaximus>(Lifetime.Singleton);
            builder.Register<IResolutorPuellaeSonusMotusMaximus, ResolutorPuellaeSonusMotusMaximus>(Lifetime.Singleton);

            builder.Register<IResolutorCivisVitaeMaxima, ResolutorCivisVitaeMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisVisusMaxima, ResolutorCivisVisusMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisAuditusMaxima, ResolutorCivisAuditusMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisSuspectaMaxima, ResolutorCivisSuspectaMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisStudiumMaxima, ResolutorCivisStudiumMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisIntentioMaxima, ResolutorCivisIntentioMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisTorelantiaAnomaliaeMaximaMaxima, ResolutorCivisTorelantiaAnomaliaeMaximaMaxima>(Lifetime.Singleton);
            builder.Register<IResolutorCivisTorelantiaAnomaliaeMinimaMaxima, ResolutorCivisTorelantiaAnomaliaeMinimaMaxima>(Lifetime.Singleton);

            // Miles
            builder.Register<MilesPuellaeActionis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVestitae>(Lifetime.Singleton);
            builder.Register<MilesCivisActionis>(Lifetime.Singleton);
            builder.Register<MilesCivisCustodiae>(Lifetime.Singleton);
            builder.Register<MilesCivisGenerationis>(Lifetime.Singleton);
            builder.Register<MilesCivisVeletudinisMaxima>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVeletudinisMaxima>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVeletudinisAnomaliae>(Lifetime.Singleton);

            // Operatio
            builder.Register<OperatioCenturioCivis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            // Centurio
            builder.Register<CenturioPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<CenturioCivis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // 単一Randomソース
            builder.RegisterInstance(new Random());

            // Legatus
            builder.Register<ILegatus, Legatus>(Lifetime.Singleton);
        }
    }
}
