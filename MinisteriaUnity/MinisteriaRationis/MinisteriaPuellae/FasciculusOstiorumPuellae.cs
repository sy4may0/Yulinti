using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellae : IPulsabilis, IPulsabilisTardus {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        private readonly MinisteriumPuellaeFigurae _miPuellaeFigurae;
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
            ITemporis temporis,
            IVasculumMinisteriumPuellae vasculum
        ) {
            _miPuellaeOssis = new MinisteriumPuellaeOssis(vasculum.AnchoraPuellae);
            _miPuellaeLoci = new MiniateriumPuellaeLoci(vasculum.AnchoraPuellae, temporis);
            _miPuellaeAnimationes = new MinisteriumPuellaeAnimationes(vasculum.Configuratio.Animatio, vasculum.AnchoraPuellae);
            _miPuellaeFigurae = new MinisteriumPuellaeFigurae(vasculum.Configuratio.Figura, vasculum.AnchoraPuellae);
            _miPuellaeRelationisTerrae = new MinisteriumPuellaeRelationisTerrae(
                vasculum.Configuratio.Relatio.Terrae, vasculum.AnchoraPuellae
            );

            _osPuellaeOssisLeg = new OstiumPuellaeOssisLegibile(_miPuellaeOssis);
            _osPuellaeOssisMut = new OstiumPuellaeOssisMutabile(_miPuellaeOssis);
            _osPuellaeLociLeg = new OstiumPuellaeLociLegibile(_miPuellaeLoci);
            _osPuellaeLociMut = new OstiumPuellaeLociMutabile(_miPuellaeLoci);
            _osPuellaeAnimationesM = new OstiumPuellaeAnimationesMutabile(_miPuellaeAnimationes);
            _osPuellaeFiguraePelvisLeg = new OstiumPuellaeFiguraePelvisLegibile(_miPuellaeFigurae.Pelvis);
            _osPuellaeFiguraePelvisMut = new OstiumPuellaeFiguraePelvisMutabile(_miPuellaeFigurae.Pelvis);
            _osPuellaeFiguraeGenusSinLeg = new OstiumPuellaeFiguraeGenusLegibile(_miPuellaeFigurae.GenusSin);
            _osPuellaeFiguraeGenusSinMut = new OstiumPuellaeFiguraeGenusMutabile(_miPuellaeFigurae.GenusSin);
            _osPuellaeFiguraeGenusDexLeg = new OstiumPuellaeFiguraeGenusLegibile(_miPuellaeFigurae.GenusDex);
            _osPuellaeFiguraeGenusDexMut = new OstiumPuellaeFiguraeGenusMutabile(_miPuellaeFigurae.GenusDex);
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
            // Grounder更新は無ぁE��E
        }
    }
}



