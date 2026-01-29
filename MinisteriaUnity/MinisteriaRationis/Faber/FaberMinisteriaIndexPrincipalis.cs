using VContainer;
using VContainer.Unity;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public static class FaberMinisteriaIndexPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            // Temporis
            builder.Register<FonsTemporis>(Lifetime.Singleton);
            builder.Register<ITemporis, Temporis>(Lifetime.Singleton);

            // Nuclei
            builder.Register<IOstiumTemporisLegibile, OstiumTemporisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumErrorumLegibile, OstiumErrorumLegibile>(Lifetime.Singleton);

            //Input
            builder.Register<MinisteriumInputVelum>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumInputVelumLegibile, OstiumInputVelumLegibile>(Lifetime.Singleton);
        }
    }
}