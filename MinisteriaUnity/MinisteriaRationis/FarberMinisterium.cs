using VContainer;
using VContainer.Unity;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FarberMinisterium : LifetimeScope {

        public FarberMinisterium() {
            // 何もしない
        }

        protected override void Configure(IContainerBuilder builder) {
            // Temporis
            builder.Register<FonsTemporis>(Lifetime.Singleton);
            builder.Register<ITemporis, Temporis>(Lifetime.Singleton);

            // Nuclei
            builder.Register<IOstiumTemporisLegibile, OstiumTemporisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumErrorumLegibile, OstiumErrorumLegibile>(Lifetime.Singleton);

            // Camera
            builder.Register<MinisteriumCamera>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IOstiumCameraLegibile, OstiumCameraLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumCameraMutabile, OstiumCameraMutabile>(Lifetime.Singleton);

            // Input
            builder.Register<MinisteriumInputMotus>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IOstiumInputMotusLegibile, OstiumInputMotusLegibile>(Lifetime.Singleton);

            // Puellae
            builder.Register<MinisteriumPuellaeLoci>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeAnimationes>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeFiguraeGenus>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeFiguraePelvis>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeOssis>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeRelationisTerrae>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IOstiumPuellaeAnimationesMutabile, OstiumPuellaeAnimationesMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraeGenusLegibile, OstiumPuellaeFiguraeGenusLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraeGenusMutabile, OstiumPuellaeFiguraeGenusMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraePelvisLegibile, OstiumPuellaeFiguraePelvisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraePelvisMutabile, OstiumPuellaeFiguraePelvisMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeLociLegibile, OstiumPuellaeLociLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeLociMutabile, OstiumPuellaeLociMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeOssisLegibile, OstiumPuellaeOssisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeOssisMutabile, OstiumPuellaeOssisMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeRelationisTerraeLegibile, OstiumPuellaeRelationisTerraeLegibile>(Lifetime.Singleton);

            // PuellaeCrinis
            builder.Register<MinisteriumPuellaeCrinisAdiunctionis>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IOstiumPuellaeCrinisAdiunctionisMutabile, OstiumPuellaeCrinisAdiunctionisMutabile>(Lifetime.Singleton);

            // Ministeria
            builder.Register<IMinisteria, Ministeria>(Lifetime.Singleton);
        }
    }
}