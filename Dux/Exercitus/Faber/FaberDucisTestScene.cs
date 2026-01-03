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

            // ContextusOstiorum
            builder.Register<ContextusPuellaeOstiorumLegibile>(Lifetime.Singleton);
            builder.Register<ContextusCivisOstiorumLegibile>(Lifetime.Singleton);

            // Miles
            builder.Register<MilesPuellaeActionis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeVeletudinis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeCrinis>(Lifetime.Singleton);
            builder.Register<MilesPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<MilesCivisVeletudinis>(Lifetime.Singleton);
            builder.Register<MilesCivisActionis>(Lifetime.Singleton);

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