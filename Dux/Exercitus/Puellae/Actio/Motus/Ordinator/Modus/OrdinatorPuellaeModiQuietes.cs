using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatorPuellaeModiQuietes : IOrdinatorPuellaeModi {
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly IConfiguratioPuellaeStatusCorporis _configurationCorporis;
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumCameraLegibile _osCameraLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;

        public OrdinatorPuellaeModiQuietes(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis configurationCorporis,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumTemporisLegibile osTemporisLeg
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configurationCorporis = configurationCorporis;
            _osInputMotusLeg = osInputMotusLeg;
            _osCameraLeg = osCameraLeg;
            _osTemporisLeg = osTemporisLeg;
        }

        public OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            OrdinatioPuellaeMotusHorizontalis oh = OrdinatorPuellaeMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                0f,
                resFluidaMotus.VelocitasActualisHorizontalis,
                _configurationCorporis.Acceleratio, _configurationCorporis.Deceleratio,
                _configuratioStatuum.TempusLevigatumMin,
                _configuratioStatuum.TempusLevigatumMax,
                _configuratioStatuum.LimenInputQuadratum,
                _configurationCorporis.EstLevigatum
            );
            OrdinatioPuellaeMotusVerticalis ov = OrdinatorPuellaeMotus.OrdinareMotusVerticalis(
                resFluidaMotus.EstInTerra,
                resFluidaMotus.VelocitasActualisVerticalis,
                _configuratioStatuum.AcceleratioGravitatis,
                _configuratioStatuum.VelocitasContactus,
                _configuratioStatuum.VelocitasVerticalisMax,
                _osTemporisLeg.Intervallum
            );
            OrdinatioPuellaeMotusRotationisY or = OrdinatorPuellaeMotus.OrdinareMotusSineRotationisY(
                resFluidaMotus.RotatioYActualis
            );
            return new OrdinatioPuellaeMotus(oh, ov, or);
        }
    }
}
