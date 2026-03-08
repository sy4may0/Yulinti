using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
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

            builder.Register<ResFluidaPuellaeLegibile>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

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

            // ContextusOstiorum
            builder.Register<ContextusPuellaeOstiorumLegibile>(Lifetime.Singleton);

            // Executor
            builder.Register<ExecutorPuellaeAnimationis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeLoci>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaeVeletudinis>(Lifetime.Singleton);
            builder.Register<ExecutorPuellaePersonae>(Lifetime.Singleton);

            // Miles
            builder.Register<MilesPuellaeActionis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVestitae>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVigoris>(Lifetime.Singleton);

            // Centurio
            builder.Register<CenturioPuellae>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();


            // Legatus
            builder.Register<LegatusPortus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            // CuratorVela
            builder.Register<CuratorVela>(Lifetime.Singleton);

            // DuxExercitus
            builder.Register<IDuxExercitus, DuxExercitus>(Lifetime.Singleton);
        }
    }
}
