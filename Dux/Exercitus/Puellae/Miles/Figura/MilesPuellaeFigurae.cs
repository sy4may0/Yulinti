using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeFigurae {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        // VContainer注入
        public MilesPuellaeFigurae(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
        }

        private void FiguroGenu() {
            IOstiumPuellaeOssisLegibile os = _contextusOstiorum.Ossis;

            float angulusGenusDexteri = 180f - InstrumentaVectorialis.AngulusTriumPunctorum(
                os.LegoPositionem(IDPuellaeOssis.RightLowerLeg),
                os.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                os.LegoPositionem(IDPuellaeOssis.RightFoot)
            );
            float angulusGenusSinisteri = 180f - InstrumentaVectorialis.AngulusTriumPunctorum(
                os.LegoPositionem(IDPuellaeOssis.LeftLowerLeg),
                os.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                os.LegoPositionem(IDPuellaeOssis.LeftFoot)
            );

            float pondus90Dex = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusDexteri, 0f, 90f, 160f);
            float pondus150Dex = 100 * InstrumentaVectorialis.AngulusAdPondus(angulusGenusDexteri, 90f, 160f);
            float pondus120OffsetDex = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusDexteri, 90f, 120f, 160f);

            float pondus90Sin = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusSinisteri, 0f, 90f, 160f);
            float pondus150Sin = 100 * InstrumentaVectorialis.AngulusAdPondus(angulusGenusSinisteri, 90f, 160f);
            float pondus120OffsetSin = 100 * InstrumentaVectorialis.AngulusAdTriPondus(angulusGenusSinisteri, 90f, 120f, 160f);

            _contextusOstiorum.Carrus.ExecutareFiguraeGenus(IDPuellaeFiguraeGenus.csknee90, LatusPuellaeGenus.Dextra, pondus90Dex);
            _contextusOstiorum.Carrus.ExecutareFiguraeGenus(IDPuellaeFiguraeGenus.csknee150, LatusPuellaeGenus.Dextra, pondus150Dex);
            _contextusOstiorum.Carrus.ExecutareFiguraeGenus(IDPuellaeFiguraeGenus.csknee120Offset, LatusPuellaeGenus.Dextra, pondus120OffsetDex);
            _contextusOstiorum.Carrus.ExecutareFiguraeGenus(IDPuellaeFiguraeGenus.csknee90, LatusPuellaeGenus.Sinistra, pondus90Sin);
            _contextusOstiorum.Carrus.ExecutareFiguraeGenus(IDPuellaeFiguraeGenus.csknee150, LatusPuellaeGenus.Sinistra, pondus150Sin);
            _contextusOstiorum.Carrus.ExecutareFiguraeGenus(IDPuellaeFiguraeGenus.csknee120Offset, LatusPuellaeGenus.Sinistra, pondus120OffsetSin);
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
            IOstiumPuellaeOssisLegibile os = _contextusOstiorum.Ossis;
            float angulusX150Dex = InstrumentaVectorialis.AngulusTriumPunctorum(
                os.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                os.LegoPositionem(IDPuellaeOssis.RightX150pin),
                os.LegoPositionem(IDPuellaeOssis.RightLowerLeg)
            );
            float angulusY90Dex = InstrumentaVectorialis.AngulusTriumPunctorum(
                os.LegoPositionem(IDPuellaeOssis.RightUpperLeg),
                os.LegoPositionem(IDPuellaeOssis.RightY90pin),
                os.LegoPositionem(IDPuellaeOssis.RightLowerLeg)
            );
            float angulusX150Sin = InstrumentaVectorialis.AngulusTriumPunctorum(
                os.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                os.LegoPositionem(IDPuellaeOssis.LeftX150pin),
                os.LegoPositionem(IDPuellaeOssis.LeftLowerLeg)
            );
            float angulusY90Sin = InstrumentaVectorialis.AngulusTriumPunctorum(
                os.LegoPositionem(IDPuellaeOssis.LeftUpperLeg),
                os.LegoPositionem(IDPuellaeOssis.LeftY90pin),
                os.LegoPositionem(IDPuellaeOssis.LeftLowerLeg)
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

            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csLHipX90, pondusX90Dex);
            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csLHipX150, pondusX150Dex);
            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csLHipY90, pondusY90Dex);
            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csRHipX90, pondusX90Sin);
            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csRHipX150, pondusX150Sin);
            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csRHipY90, pondusY90Sin);
            _contextusOstiorum.Carrus.ExecutareFiguraePelvis(IDPuellaeFiguraePelvis.csAnusX150, pondusAni);
        }

        public void Ordinare() {
            FiguroGenu();
            FiguroPelvim();
        }
    }
}
