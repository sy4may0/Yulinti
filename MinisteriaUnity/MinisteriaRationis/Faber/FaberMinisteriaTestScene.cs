using VContainer;
using VContainer.Unity;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public static class FaberMinisteriaTestScene {

        public static void Initio(IContainerBuilder builder) {
            // Temporis
            builder.Register<FonsTemporis>(Lifetime.Singleton);
            builder.Register<ITemporis, Temporis>(Lifetime.Singleton);

            // Nuclei
            builder.Register<IOstiumTemporisLegibile, OstiumTemporisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumErrorumLegibile, OstiumErrorumLegibile>(Lifetime.Singleton);

            // Camera
            builder.Register<MinisteriumCamera>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumCameraLegibile, OstiumCameraLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumCameraMutabile, OstiumCameraMutabile>(Lifetime.Singleton);

            // Input
            builder.Register<MinisteriumInputMotus>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumInputMotusLegibile, OstiumInputMotusLegibile>(Lifetime.Singleton);

            // Puellae
            builder.Register<MinisteriumPuellaeLoci>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeAnimationes>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeFiguraeGenus>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeFiguraePelvis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeOssis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeRelationisTerrae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumPuellaeResVisae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
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
            builder.Register<IOstiumPuellaeResVisaeLegibile, OstiumPuellaeResVisaeLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPuellaeResVisaeMutabile, OstiumPuellaeResVisaeMutabile>(Lifetime.Singleton);

            // PuellaeCrinis
            builder.Register<MinisteriumPuellaeCrinisAdiunctionis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumPuellaeCrinisAdiunctionisMutabile, OstiumPuellaeCrinisAdiunctionisMutabile>(Lifetime.Singleton);

            // PunctumViae
            builder.Register<MinisteriumPunctumViae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumPunctumViaeLegibile, OstiumPunctumViaeLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumPunctumViaeMutabile, OstiumPunctumViaeMutabile>(Lifetime.Singleton);

            // Civis
            builder.Register<TabulaCivis>(Lifetime.Singleton);
            builder.Register<MinisteriumCivis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumCivisLoci>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumCivisAnimationes>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumCivisGenerator>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MinisteriumCivisVisae>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<IOstiumCivisLegibile, OstiumCivisLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumCivisMutabile, OstiumCivisMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumCivisLociLegibile, OstiumCivisLociLegibile>(Lifetime.Singleton);
            builder.Register<IOstiumCivisLociMutabile, OstiumCivisLociMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumCivisAnimationesMutabile, OstiumCivisAnimationesMutabile>(Lifetime.Singleton);
            builder.Register<IOstiumCivisVisaeLegibile, OstiumCivisVisaeLegibile>(Lifetime.Singleton);

            // Ministeria
            builder.Register<IMinisteria, Ministeria>(Lifetime.Singleton);
        }
    }
}