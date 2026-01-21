using VContainer;
using VContainer.Unity;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    public static class FaberDucisTestScene {
        public static void Initio(IContainerBuilder builder) {
            // ContextusResFluida
            builder.Register<ResFluidaPuellaeMotus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<ResFluidaPuellaeVeletudinis>(Lifetime.Singleton)
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

            builder.Register<ResFluidaCivisLegibile>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // Carrus
            builder.Register<CarrusPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<CarrusCivis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // ContextusOstiorum
            builder.Register<ContextusPuellaeOstiorumLegibile>(Lifetime.Singleton);
            builder.Register<ContextusCivisOstiorumLegibile>(Lifetime.Singleton);

            // Executor
            builder.Register<ExecutorPuellaeAnimationis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeLoci>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeVeletudinis>(Lifetime.Singleton);

            builder.Register<ExecutorCivisAnimationis>(Lifetime.Singleton);
            builder.Register<ExecutorCivisLoci>(Lifetime.Singleton);
            builder.Register<ExecutorCivisMortis>(Lifetime.Singleton);
            builder.Register<ExecutorCivisVeletudinis>(Lifetime.Singleton);

            // Miles
            builder.Register<MilesPuellaeActionis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVestitae>(Lifetime.Singleton);
            builder.Register<MilesCivisActionis>(Lifetime.Singleton);
            builder.Register<MilesCivisCustodiae>(Lifetime.Singleton);

            // Centurio
            builder.Register<CenturioPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<CenturioCivis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // DuxExercitus
            builder.Register<IDuxExercitus, DuxExercitus>(Lifetime.Singleton);
        }
    }
}
