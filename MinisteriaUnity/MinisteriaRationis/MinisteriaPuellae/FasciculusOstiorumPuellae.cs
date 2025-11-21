using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class FasciculusOstiorumPuellae : IPulsabilis, IPulsabilisTardus {
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

        private readonly ITemporis _temporis;

        public FasciculusOstiorumPuellae(
            FasciculusConfigurationumPuellae config, ITemporis temporis
        ) {
            if (config == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumPuellaeのFasciculusConfigurationumPuellaeがnullです。");
            }

            _miPuellaeOssis = new MinisteriumPuellaeOssis(config.Ossis);
            _miPuellaeLoci = new MiniateriumPuellaeLoci(config.Locus, temporis);
            _miPuellaeAnimationes = new MinisteriumPuellaeAnimationes(config.Animationis);
            _miPuellaeFiguraePelvis = new MinisteriumPuellaeFiguraePelvis(config.Figura.Pelvis);
            _miPuellaeFiguraeGenusSin = new MinisteriumPuellaeFiguraeGenus(config.Figura.GenusSin);
            _miPuellaeFiguraeGenusDex = new MinisteriumPuellaeFiguraeGenus(config.Figura.GenusDex);
            _miPuellaeRelationisTerrae = new MinisteriumPuellaeRelationisTerrae(config.RelatioTerrae);
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

        public OstiumPuellaeOssisLegibile OsLeg => _osPuellaeOssisLeg;
        public OstiumPuellaeOssisMutabile OsMut => _osPuellaeOssisMut;
        public OstiumPuellaeLociLegibile LocusLeg => _osPuellaeLociLeg;
        public OstiumPuellaeLociMutabile LocusMut => _osPuellaeLociMut;
        public OstiumPuellaeAnimationesMutabile AnimatioMut => _osPuellaeAnimationesM;
        public OstiumPuellaeFiguraePelvisLegibile FiguraPelvisLeg => _osPuellaeFiguraePelvisLeg;
        public OstiumPuellaeFiguraePelvisMutabile FiguraPelvisMut => _osPuellaeFiguraePelvisMut;
        public OstiumPuellaeFiguraeGenusLegibile FiguraGenusSinLeg => _osPuellaeFiguraeGenusSinLeg;
        public OstiumPuellaeFiguraeGenusMutabile FiguraGenusSinMut => _osPuellaeFiguraeGenusSinMut;
        public OstiumPuellaeFiguraeGenusLegibile FiguraGenusDexLeg => _osPuellaeFiguraeGenusDexLeg;
        public OstiumPuellaeFiguraeGenusMutabile FiguraGenusDexMut => _osPuellaeFiguraeGenusDexMut;
        public OstiumPuellaeRelationisTerraeLegibile RelatioTerraeLeg => _osPuellaeRelationisTerraeLeg;

        public void Pulsus() {
            _miPuellaeAnimationes.Pulsus();
            _miPuellaeLoci.Pulsus();
        }

        public void PulsusTardus() {
            // Grounder更新は無い。
        }
    }
}