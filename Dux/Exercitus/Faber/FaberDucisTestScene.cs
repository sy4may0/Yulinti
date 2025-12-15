using VContainer;
using VContainer.Unity;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    public static class FaberDucisTestScene {
        public static void Initio(IContainerBuilder builder) {
            // Puellae
            builder.Register<IMilesPuellaeActionis, MilesPuellaeActionis>(Lifetime.Singleton);
            builder.Register<IMilesPuellaeActionisSecundarius, MilesPuellaeActionisSecundarius>(Lifetime.Singleton);
            builder.Register<IMilesPuellaeFigurae, MilesPuellaeFigurae>(Lifetime.Singleton);
            builder.Register<IMilesPuellaeCrinis, MilesPuellaeCrinis>(Lifetime.Singleton);

            builder.Register<CenturioPuellae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<IDuxExercitus, DuxExercitus>(Lifetime.Singleton);
        }
    }
}