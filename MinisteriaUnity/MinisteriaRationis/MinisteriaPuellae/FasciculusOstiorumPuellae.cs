using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellae : IPulsabilis, IPulsabilisTardus {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePelvis;
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenusSin;
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenusDex;
        private readonly MinisteriumPuellaeRelationisTerrae _miPuellaeRelationisTerrae;

        private readonly IOstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly IOstiumPuellaeOssisMutabile _osPuellaeOssisMut;

        private readonly IOstiumPuellaeLociLegibile _osPuellaeLociLeg;
        private readonly IOstiumPuellaeLociMutabile _osPuellaeLociMut;

        private readonly IOstiumPuellaeAnimationesMutabile _osPuellaeAnimationesM;

        private readonly IOstiumPuellaeFiguraePelvisLegibile _osPuellaeFiguraePelvisLeg;
        private readonly IOstiumPuellaeFiguraePelvisMutabile _osPuellaeFiguraePelvisMut;
        private readonly IOstiumPuellaeFiguraeGenusLegibile _osPuellaeFiguraeGenusSinLeg;
        private readonly IOstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusSinMut;
        private readonly IOstiumPuellaeFiguraeGenusLegibile _osPuellaeFiguraeGenusDexLeg;
        private readonly IOstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusDexMut;

        private readonly IOstiumPuellaeRelationisTerraeLegibile _osPuellaeRelationisTerraeLeg;

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
            _osPuellaeRelationisTerraeLeg = new OstiumPuellaeRelationisTerraeLegibile(_miPuellaeRelationisTerrae);
        }

        public IOstiumPuellaeOssisLegibile OsLeg => _osPuellaeOssisLeg;
        public IOstiumPuellaeOssisMutabile OsMut => _osPuellaeOssisMut;
        public IOstiumPuellaeLociLegibile LocusLeg => _osPuellaeLociLeg;
        public IOstiumPuellaeLociMutabile LocusMut => _osPuellaeLociMut;
        public IOstiumPuellaeAnimationesMutabile AnimatioMut => _osPuellaeAnimationesM;
        public IOstiumPuellaeFiguraePelvisLegibile FiguraPelvisLeg => _osPuellaeFiguraePelvisLeg;
        public IOstiumPuellaeFiguraePelvisMutabile FiguraPelvisMut => _osPuellaeFiguraePelvisMut;
        public IOstiumPuellaeFiguraeGenusLegibile FiguraGenusSinLeg => _osPuellaeFiguraeGenusSinLeg;
        public IOstiumPuellaeFiguraeGenusMutabile FiguraGenusSinMut => _osPuellaeFiguraeGenusSinMut;
        public IOstiumPuellaeFiguraeGenusLegibile FiguraGenusDexLeg => _osPuellaeFiguraeGenusDexLeg;
        public IOstiumPuellaeFiguraeGenusMutabile FiguraGenusDexMut => _osPuellaeFiguraeGenusDexMut;
        public IOstiumPuellaeRelationisTerraeLegibile RelatioTerraeLeg => _osPuellaeRelationisTerraeLeg;

        public void Pulsus() {
            _miPuellaeAnimationes.Pulsus();
        }

        public void PulsusTardus() {
            // Grounder更新は無い。
        }
    }
}