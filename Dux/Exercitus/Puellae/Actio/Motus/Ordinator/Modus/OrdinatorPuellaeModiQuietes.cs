using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatorPuellaeModiQuietes : IOrdinatorPuellaeModi {
        private readonly ThesaurusPuellaeStatuum _thesaurus;
        private readonly ThesaurusPuellaeStatusCorporis _thesaurusStatus;
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumCameraLegibile _osCameraLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;

        public OrdinatorPuellaeModiQuietes(IContentumOrdinatorPuellaeModi contentum) {
            _thesaurus = contentum.Thesaurus;
            _thesaurusStatus = contentum.ThesaurusStatus;
            _osInputMotusLeg = contentum.OsInputMotus;
            _osCameraLeg = contentum.OsCamera;
            _osTemporisLeg = contentum.OsTemporis;
        }

        public OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            OrdinatioPuellaeMotusHorizontalis oh = OrdinatorPuellaeMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                0f,
                resFluidaMotus.VelocitasActualisHorizontalis,
                _thesaurusStatus.Acceleratio, _thesaurusStatus.Deceleratio,
                _thesaurus.TempusLevigatumMin,
                _thesaurus.TempusLevigatumMax,
                _thesaurus.LimenInputQuadratum,
                _thesaurusStatus.EstLevigatum
            );
            OrdinatioPuellaeMotusVerticalis ov = OrdinatorPuellaeMotus.OrdinareMotusVerticalis(
                resFluidaMotus.EstInTerra,
                resFluidaMotus.VelocitasActualisVerticalis,
                _thesaurus.AcceleratioGravitatis,
                _thesaurus.VelocitasContactus,
                _thesaurus.VelocitasVerticalisMax,
                _osTemporisLeg.Intervallum
            );
            OrdinatioPuellaeMotusRotationisY or = OrdinatorPuellaeMotus.OrdinareMotusSineRotationisY(
                resFluidaMotus.RotatioYActualis
            );
            return new OrdinatioPuellaeMotus(oh, ov, or);
        }
    }
}