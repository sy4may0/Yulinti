using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Miles {
    internal sealed class Figura {
        private readonly IOstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly IOstiumPuellaeFiguraePelvisMutabile _osPuellaeFiguraePelvisMut;
        private readonly IOstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusDexMut;
        private readonly IOstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusSinMut;

        public Figura(
            IOstiumPuellaeOssisLegibile osPuellaeOssisLeg,
            IOstiumPuellaeFiguraePelvisMutabile osPuellaeFiguraePelvisMut,
            IOstiumPuellaeFiguraeGenusMutabile osPuellaeFiguraeGenusDexMut,
            IOstiumPuellaeFiguraeGenusMutabile osPuellaeFiguraeGenusSinMut
        ) {
            _osPuellaeOssisLeg = osPuellaeOssisLeg;
            _osPuellaeFiguraePelvisMut = osPuellaeFiguraePelvisMut;
            _osPuellaeFiguraeGenusDexMut = osPuellaeFiguraeGenusDexMut;
            _osPuellaeFiguraeGenusSinMut = osPuellaeFiguraeGenusSinMut;
        }

        private void FiguroGenu() {
            // 180 -> 0蠎ｦ縺ｫ霑代▼縺上↓縺､繧後え繧ｧ繧､繝医ｒ荳翫￡繧九・雜ｳ縺御ｼｸ縺ｳ縺ｦ繧後・180蠎ｦ縺繧阪・
            float angulusGenusDexteri = 180f - InstrumentaFigurae.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightLowerLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightFoot)
            );
            float angulusGenusSinisteri = 180f - InstrumentaFigurae.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftLowerLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftFoot)
            );

            float pondus90Dex = InstrumentaFigurae.AngulusAdTriPondus(angulusGenusDexteri, 0f, 90f, 160f);
            float pondus150Dex = InstrumentaFigurae.AngulusAdPondus(angulusGenusDexteri, 90f, 160f);
            float pondus120OffsetDex = InstrumentaFigurae.AngulusAdTriPondus(angulusGenusDexteri, 90f, 120f, 160f);

            float pondus90Sin = InstrumentaFigurae.AngulusAdTriPondus(angulusGenusSinisteri, 0f, 90f, 160f);
            float pondus150Sin = InstrumentaFigurae.AngulusAdPondus(angulusGenusSinisteri, 90f, 160f);
            float pondus120OffsetSin = InstrumentaFigurae.AngulusAdTriPondus(angulusGenusSinisteri, 90f, 120f, 160f);

            _osPuellaeFiguraeGenusDexMut.PonoPondus(IDPuellaeFiguraeGenus.csknee90, pondus90Dex);
            _osPuellaeFiguraeGenusDexMut.PonoPondus(IDPuellaeFiguraeGenus.csknee150, pondus150Dex);
            _osPuellaeFiguraeGenusDexMut.PonoPondus(IDPuellaeFiguraeGenus.csknee120Offset, pondus120OffsetDex);
            _osPuellaeFiguraeGenusSinMut.PonoPondus(IDPuellaeFiguraeGenus.csknee90, pondus90Sin);
            _osPuellaeFiguraeGenusSinMut.PonoPondus(IDPuellaeFiguraeGenus.csknee150, pondus150Sin);
            _osPuellaeFiguraeGenusSinMut.PonoPondus(IDPuellaeFiguraeGenus.csknee120Offset, pondus120OffsetSin);
        }

        private float CalculateXCapacitatemSquamae(float pondusX90, float pondusX150, float pondusY90) {
            float capacitas = MathF.Max(0f, 100f - pondusY90);
            float summa = pondusX90 + pondusX150;

            if (summa > capacitas) {
                return capacitas / MathF.Max(summa, Numerus.Epsilon);
            } else {
                return 1f;
            }
        }

        private void FiguroPelvim() {
            // Knee縺ｨ驕輔▲縺ｦReverse隗貞ｺｦ縺ｫ縺ｪ縺｣縺ｦ縺・↑縺・・ngulusAd繧偵ｈ縺剰ｦ九ｍ縲・
            float angulusX150Dex = InstrumentaFigurae.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightX150pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightLowerLeg)
            );
            float angulusY90Dex = InstrumentaFigurae.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightY90pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightLowerLeg)
            );
            float angulusX150Sin = InstrumentaFigurae.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftX150pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftLowerLeg)
            );
            float angulusY90Sin = InstrumentaFigurae.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftY90pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftLowerLeg)
            );

            float pondusX90Dex = InstrumentaFigurae.AngulusAdTriPondus(angulusX150Dex, 0f, 40f, 130f);
            float pondusX150Dex = InstrumentaFigurae.AngulusAdPondusInversum(angulusX150Dex, 0f, 40f);
            float pondusY90Dex = InstrumentaFigurae.AngulusAdPondusInversum(angulusY90Dex, 0f, 90f);
            float pondusX90Sin = InstrumentaFigurae.AngulusAdTriPondus(angulusX150Sin, 0f, 50f, 130f);
            float pondusX150Sin = InstrumentaFigurae.AngulusAdPondusInversum(angulusX150Sin, 0f, 40f);
            float pondusY90Sin = InstrumentaFigurae.AngulusAdPondusInversum(angulusY90Sin, 0f, 90f);
            float pondusAni = (pondusX150Dex + pondusX150Sin) / 2f;

            // (X90 + X150) + Y90縺・00縺ｫ縺ｪ繧九ｈ縺・↓隱ｿ謨ｴ縺吶ｋ縲・
            float squamaeDex = CalculateXCapacitatemSquamae(pondusX90Dex, pondusX150Dex, pondusY90Dex);
            float squamaeSin = CalculateXCapacitatemSquamae(pondusX90Sin, pondusX150Sin, pondusY90Sin);
            pondusX90Dex *= squamaeDex;
            pondusX150Dex *= squamaeDex;
            pondusX90Sin *= squamaeSin;
            pondusX150Sin *= squamaeSin;

            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csLHipX90, pondusX90Dex);
            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csLHipX150, pondusX150Dex);
            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csLHipY90, pondusY90Dex);
            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csRHipX90, pondusX90Sin);
            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csRHipX150, pondusX150Sin);
            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csRHipY90, pondusY90Sin);
            _osPuellaeFiguraePelvisMut.PonoPondus(IDPuellaeFiguraePelvis.csAnusX150, pondusAni);
        }


        public void ApplicareFiguram() {
            FiguroGenu();
            FiguroPelvim();
        }
    }
}
