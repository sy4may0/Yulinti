using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    public static class FaberMinisteriaPortus {

        public static void Initio(IContainerBuilder builder) {
            // Temporis
            builder.Register<FonsTemporis>(Lifetime.Singleton);
            builder.Register<ITemporis, Temporis>(Lifetime.Singleton);

            // Nuclei
            builder.Register<IOstiumTemporisLegibile, OstiumTemporisLegibile>(Lifetime.Singleton);

            // Camera
            builder.Register<MinisteriumCamera>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumCameraLegibile, OstiumCameraLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumCameraMutabile, OstiumCameraMutabile>(Lifetime.Singleton);

            // Puellae
            builder.Register<MinisteriumPuellaeLoci>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeAnimationis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeFiguraeGenus>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeFiguraePelvis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeOssis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeRelationisTerrae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeResVisae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumPuellaeAnimationisMutabile, OstiumPuellaeAnimationisMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraeGenusLegibile, OstiumPuellaeFiguraeGenusLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraeGenusMutabile, OstiumPuellaeFiguraeGenusMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraePelvisLegibile, OstiumPuellaeFiguraePelvisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeFiguraePelvisMutabile, OstiumPuellaeFiguraePelvisMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeLociLegibile, OstiumPuellaeLociLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeLociMutabile, OstiumPuellaeLociMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeOssisLegibile, OstiumPuellaeOssisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeOssisMutabile, OstiumPuellaeOssisMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeRelationisTerraeLegibile, OstiumPuellaeRelationisTerraeLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeResVisaeLegibile, OstiumPuellaeResVisaeLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeResVisaeMutabile, OstiumPuellaeResVisaeMutabile>(Lifetime.Singleton);

            // PuellaeCrinis
            builder.Register<MinisteriumPuellaeCrinisAdiunctionis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumPuellaeCrinisAdiunctionisMutabile, OstiumPuellaeCrinisAdiunctionisMutabile>(Lifetime.Singleton);

            // Ministeria
            builder.Register<IMinisteria, Ministeria>(Lifetime.Singleton);
        }
    }
}