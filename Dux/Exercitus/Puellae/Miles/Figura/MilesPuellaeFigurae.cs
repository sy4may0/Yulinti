using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeFigurae {
        private readonly IOstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly IOstiumPuellaeFiguraePelvisMutabile _osPuellaeFiguraePelvisMut;
        private readonly IOstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusMut;

        // VContainer注入
        public MilesPuellaeFigurae(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeFiguraePelvisMutabile osPuellaeFiguraePelvisMut,
            IOstiumPuellaeFiguraeGenusMutabile osPuellaeFiguraeGenusMut
        ) {
            _osPuellaeOssisLeg = contextusOstiorum.Ossis;
            _osPuellaeFiguraePelvisMut = osPuellaeFiguraePelvisMut;
            _osPuellaeFiguraeGenusMut = osPuellaeFiguraeGenusMut;
        }

        private void FiguroGenu() {
            float angulusGenusDexteri = 180f - InstrumentaVectorialis.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightLowerLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightFoot)
            );
            float angulusGenusSinisteri = 180f - InstrumentaVectorialis.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftLowerLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftFoot)
            );

            float pondus90Dex = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusDexteri, 0f, 90f, 160f);
            float pondus150Dex = 100 * InstrumentaVectorialis.AngulusAdPondus(angulusGenusDexteri, 90f, 160f);
            float pondus120OffsetDex = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusDexteri, 90f, 120f, 160f);

            float pondus90Sin = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusSinisteri, 0f, 90f, 160f);
            float pondus150Sin = 100 * InstrumentaVectorialis.AngulusAdPondus(angulusGenusSinisteri, 90f, 160f);
            float pondus120OffsetSin = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusSinisteri, 90f, 120f, 160f);

            _osPuellaeFiguraeGenusMut.PonoPondusDexter(IDPuellaeFiguraeGenus.csknee90, pondus90Dex);
            _osPuellaeFiguraeGenusMut.PonoPondusDexter(IDPuellaeFiguraeGenus.csknee150, pondus150Dex);
            _osPuellaeFiguraeGenusMut.PonoPondusDexter(IDPuellaeFiguraeGenus.csknee120Offset, pondus120OffsetDex);
            _osPuellaeFiguraeGenusMut.PonoPondusSinister(IDPuellaeFiguraeGenus.csknee90, pondus90Sin);
            _osPuellaeFiguraeGenusMut.PonoPondusSinister(IDPuellaeFiguraeGenus.csknee150, pondus150Sin);
            _osPuellaeFiguraeGenusMut.PonoPondusSinister(IDPuellaeFiguraeGenus.csknee120Offset, pondus120OffsetSin);
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
            float angulusX150Dex = InstrumentaVectorialis.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightX150pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightLowerLeg)
            );
            float angulusY90Dex = InstrumentaVectorialis.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightY90pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightLowerLeg)
            );
            float angulusX150Sin = InstrumentaVectorialis.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftX150pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftLowerLeg)
            );
            float angulusY90Sin = InstrumentaVectorialis.AngulusTriumPunctorum(
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftY90pin),
                _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftLowerLeg)
            );

            float pondusX90Dex = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusX150Dex, 0f, 40f, 130f);
            float pondusX150Dex = 100 * InstrumentaVectorialis.AngulusAdPondusInversum(angulusX150Dex, 0f, 40f);
            float pondusY90Dex = 100 * InstrumentaVectorialis.AngulusAdPondusInversum(angulusY90Dex, 0f, 90f);
            float pondusX90Sin = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusX150Sin, 0f, 50f, 130f);
            float pondusX150Sin = 100 * InstrumentaVectorialis.AngulusAdPondusInversum(angulusX150Sin, 0f, 40f);
            float pondusY90Sin = 100 * InstrumentaVectorialis.AngulusAdPondusInversum(angulusY90Sin, 0f, 90f);
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
