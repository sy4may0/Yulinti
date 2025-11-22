using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.Dux.Miles {
    internal sealed class FasciculusOstiorumPuellae {
        // Ministeria Nuclei
        private readonly IOstiumErrorumLegibile _osErrorumLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;

        // Ministeria Input
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;

        // Ministeria Camera
        private readonly IOstiumCameraLegibile _osCameraPriLeg;

        // Ministeria PueIllae
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

        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _osPuellaeCrinisAdiunctionisMut;

        public FasciculusOstiorumPuellae(
            FasciculusOstiorumRationis osRationis
        ) {
            _osErrorumLeg = osRationis.Nuclei.ErrorLeg;
            _osTemporisLeg = osRationis.Nuclei.TempusLeg;
            _osInputMotusLeg = osRationis.Input.MotusLeg;
            _osCameraPriLeg = osRationis.Camera.PrincepsLeg;
            _osPuellaeOssisLeg = osRationis.Puellae.OsLeg;
            _osPuellaeOssisMut = osRationis.Puellae.OsMut;
            _osPuellaeLociLeg = osRationis.Puellae.LocusLeg;
            _osPuellaeLociMut = osRationis.Puellae.LocusMut;
            _osPuellaeAnimationesM = osRationis.Puellae.AnimatioMut;
            _osPuellaeFiguraePelvisLeg = osRationis.Puellae.FiguraPelvisLeg;
            _osPuellaeFiguraePelvisMut = osRationis.Puellae.FiguraPelvisMut;
            _osPuellaeFiguraeGenusSinLeg = osRationis.Puellae.FiguraGenusSinLeg;
            _osPuellaeFiguraeGenusSinMut = osRationis.Puellae.FiguraGenusSinMut;
            _osPuellaeFiguraeGenusDexLeg = osRationis.Puellae.FiguraGenusDexLeg;
            _osPuellaeFiguraeGenusDexMut = osRationis.Puellae.FiguraGenusDexMut;
            _osPuellaeRelationisTerraeLeg = osRationis.Puellae.RelatioTerraeLeg;
            _osPuellaeCrinisAdiunctionisMut = osRationis.PuellaeCrinis.OsPuellaeCrinisAdiunctionisMut;
        }

        public IOstiumErrorumLegibile ErrorumLeg => _osErrorumLeg;
        public IOstiumTemporisLegibile TemporisLeg => _osTemporisLeg;
        public IOstiumInputMotusLegibile InputMotusLeg => _osInputMotusLeg;
        public IOstiumCameraLegibile CameraPriLeg => _osCameraPriLeg;
        public IOstiumPuellaeOssisLegibile PuellaeOssisLeg => _osPuellaeOssisLeg;
        public IOstiumPuellaeOssisMutabile PuellaeOssisMut => _osPuellaeOssisMut;
        public IOstiumPuellaeLociLegibile PuellaeLociLeg => _osPuellaeLociLeg;
        public IOstiumPuellaeLociMutabile PuellaeLociMut => _osPuellaeLociMut;
        public IOstiumPuellaeAnimationesMutabile PuellaeAnimationesMut => _osPuellaeAnimationesM;
        public IOstiumPuellaeFiguraePelvisLegibile PuellaeFiguraePelvisLeg => _osPuellaeFiguraePelvisLeg;
        public IOstiumPuellaeFiguraePelvisMutabile PuellaeFiguraePelvisMut => _osPuellaeFiguraePelvisMut;
        public IOstiumPuellaeFiguraeGenusLegibile PuellaeFiguraeGenusSinLeg => _osPuellaeFiguraeGenusSinLeg;
        public IOstiumPuellaeFiguraeGenusMutabile PuellaeFiguraeGenusSinMut => _osPuellaeFiguraeGenusSinMut;
        public IOstiumPuellaeFiguraeGenusLegibile PuellaeFiguraeGenusDexLeg => _osPuellaeFiguraeGenusDexLeg;
        public IOstiumPuellaeFiguraeGenusMutabile PuellaeFiguraeGenusDexMut => _osPuellaeFiguraeGenusDexMut;
        public IOstiumPuellaeRelationisTerraeLegibile PuellaeRelationisTerraeLeg => _osPuellaeRelationisTerraeLeg;
        public IOstiumPuellaeCrinisAdiunctionisMutabile PuellaeCrinisAdiunctionisMut => _osPuellaeCrinisAdiunctionisMut;
    }
}

