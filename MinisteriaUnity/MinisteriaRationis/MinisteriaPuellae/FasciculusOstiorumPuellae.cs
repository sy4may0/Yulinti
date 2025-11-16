using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.Nucleus.Interfacies;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellae : IPulsabilis, IPulsabilisTardus {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePelvis;
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenusSin;
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenusDex;
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;

        private readonly OstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly OstiumPuellaeOssisMutabile _osPuellaeOssisMut;

        private readonly OstiumPuellaeLociLegibile _osPuellaeLociLeg;
        private readonly OstiumPuellaeLociMutabile _osPuellaeLociMut;

        private readonly OstiumPuellaeAnimationesMutabile _osPuellaeAnimationesM;

        private readonly OstiumPuellaeFiguraePelvisLegibile _osPuellaeFiguraePelvisLeg;
        private readonly OstiumPuellaeFiguraePelvisMutabile _osPuellaeFiguraePelvisMut;
        private readonly OstiumPuellaeFiguraeGenusLegibile _osPuellaeFiguraeGenusSinLeg;
        private readonly OstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusSinMut;
        private readonly OstiumPuellaeFiguraeGenusLegibile _osPuellaeFiguraeGenusDexLeg;
        private readonly OstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusDexMut;

        private readonly OstiumPuellaeRelationisTerraeLegibile _osPuellaeRelationisTerraeLeg;

        public FasciculusOstiorumPuellae(FukaRootConfig fukaConfig) {
            if (fukaConfig == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumPuellaeのPuellaeConfigがnullです。");
            }

            _miPuellaeOssis = new MinisteriumPuellaeOssis(fukaConfig.Ossis);
            _miPuellaeLoci = new MiniateriumPuellaeLoci(fukaConfig.Locus);
            _miPuellaeAnimationes = new MinisteriumPuellaeAnimationes(fukaConfig.FukaAnimationConfig);
            _miPuellaeFiguraePelvis = new MinisteriumPuellaeFiguraePelvis(fukaConfig.Figura.Pelvis);
            _miPuellaeFiguraeGenusSin = new MinisteriumPuellaeFiguraeGenus(fukaConfig.Figura.GenusSin);
            _miPuellaeFiguraeGenusDex = new MinisteriumPuellaeFiguraeGenus(fukaConfig.Figura.GenusDex);
            _miPuellaeRelationisTerrae = new MinisteriumPuellaeRelationisTerrae(fukaConfig.RelatioTerrae);
            _osPuellaeOssisLeg = new OstiumPuellaeOssisLegibile(_miPuellaeOssis);
            _osPuellaeOssisMut = new OstiumPuellaeOssisMutabile(_miPuellaeOssis);
            _osPuellaeLociLeg = new OstiumPuellaeLociLegibile(_miPuellaeLoci);
            _osPuellaeLociMut = new OstiumPuellaeLociMutabile(_miPuellaeLoci);
            _osPuellaeAnimationesM = new OstiumPuellaeAnimationesMutabile(_miPuellaeAnimationes);
            _osPuellaeFiguraePelvisLeg = new OstiumPuellaeFiguraePelvisLegibile(_miPuellaeFiguraePelvis);
            _osPuellaeFiguraePelvisMut = new OstiumPuellaeFiguraePelvisMutabile(_miPuellaeFiguraePelvis);
            _osPuellaeFiguraeGenusSinLeg = new OstiumPuellaeFiguraeGenusLegibile(_miPuellaeFiguraeGenusSin);
            _osPuellaeFiguraeGenusSinMut = new OstiumPuellaeFiguraeGenusMutabile(_miPuellaeFiguraeGenusSin);
            _osPuellaeFiguraeGenusDexLeg = new OstiumPuellaeFiguraeGenusLegibile(_miPuellaeFiguraeGenusDex);
            _osPuellaeFiguraeGenusDexMut = new OstiumPuellaeFiguraeGenusMutabile(_miPuellaeFiguraeGenusDex);
        }

        public OstiumPuellaeOssisLegibile OssisLeg => _osPuellaeOssisLeg;
        public OstiumPuellaeOssisMutabile OssisMut => _osPuellaeOssisMut;
        public OstiumPuellaeLociLegibile LociLeg => _osPuellaeLociLeg;
        public OstiumPuellaeLociMutabile LociMut => _osPuellaeLociMut;
        public OstiumPuellaeAnimationesMutabile AnimationesMut => _osPuellaeAnimationesM;
        public OstiumPuellaeFiguraePelvisLegibile FiguraePelvisLeg => _osPuellaeFiguraePelvisLeg;
        public OstiumPuellaeFiguraePelvisMutabile FiguraePelvisMut => _osPuellaeFiguraePelvisMut;
        public OstiumPuellaeFiguraeGenusLegibile FiguraeGenusSinLeg => _osPuellaeFiguraeGenusSinLeg;
        public OstiumPuellaeFiguraeGenusMutabile FiguraeGenusSinMut => _osPuellaeFiguraeGenusSinMut;
        public OstiumPuellaeFiguraeGenusLegibile FiguraeGenusDexLeg => _osPuellaeFiguraeGenusDexLeg;
        public OstiumPuellaeFiguraeGenusMutabile FiguraeGenusDexMut => _osPuellaeFiguraeGenusDexMut;
        public OstiumPuellaeRelationisTerraeLegibile RelationisTerraeLeg => _osPuellaeRelationisTerraeLeg;

        public void Pulsus() {
            _miPuellaeAnimationes.Pulsus();
        }

        public void PulsusTardus() {
            // Grounder更新
        }
    }
}