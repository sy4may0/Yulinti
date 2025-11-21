using Yulinti.Dux.ConfigratioDucis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Miles;
using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.Dux.Miles {
    public sealed class StatusCursus : IStatusCorporis {
        private IDPuellaeAnimationisCorporis _idAnimationis;
        private float _velocitasDesiderata;
        private float _acceleratio;
        private float _deceleratio;
        private bool _estLevigatum;

        private readonly ConfiguratioPuellaeStatuumGlobalis _configuratioGlobalis;

        // DI
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;
        private readonly IOstiumCameraLegibile _osCameraLeg;

        public StatusCursus(
            ConfiguratioPuellaeStatuumGlobalis configuratioGlobalis,
            ConfiguratioPuellaeStatusCursus configuratioPuellaeStatusCursus,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg
        ) {
            _configuratioGlobalis = configuratioGlobalis;
            _idAnimationis = configuratioPuellaeStatusCursus.IdAnimationis;
            _velocitasDesiderata = configuratioPuellaeStatusCursus.VelocitasDesiderata;
            _acceleratio = configuratioPuellaeStatusCursus.Acceleratio;
            _deceleratio = configuratioPuellaeStatusCursus.Deceleratio;
            _estLevigatum = configuratioPuellaeStatusCursus.EstLevigatum;
            _osInputMotusLeg = osInputMotusLeg;
            _osTemporisLeg = osTemporisLeg;
            _osCameraLeg = osCameraLeg;
        }

        public IDStatus Id => IDStatus.Cursus;
        public IDPuellaeAnimationisCorporis IdAnimationis => _idAnimationis;

        public void Intrare(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public void Exire(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public OrdinatioMotus Ordinare(IResFuluidaMotusLegibile resFuluidaMotus) {
            OrdinatioMotusHorizontalis oh =  OrdinatorMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                _velocitasDesiderata,
                resFuluidaMotus.VelocitasActualisHorizontal,
                _acceleratio, _deceleratio,
                _configuratioGlobalis.TempusLevigatumMin,
                _configuratioGlobalis.TempusLevigatumMax,
                _configuratioGlobalis.LimenInputQuadratum,
                _estLevigatum
            );
            OrdinatioMotusVerticalis ov =  OrdinatorMotus.OrdinareMotusVerticalis(
                resFuluidaMotus.EstInTerra,
                resFuluidaMotus.VelocitasActualisVertical,
                _configuratioGlobalis.AcceleratioGravitatis,
                _configuratioGlobalis.VelocitasContactus,
                _configuratioGlobalis.VelocitasVerticalisMax,
                _osTemporisLeg.Intervallum
            );
            OrdinatioMotusRotationisY or = OrdinatorMotus.OrdinareMotusRotationisYSecutoria(
                _osCameraLeg.DexterXZ,
                _osCameraLeg.AnteriorXZ,
                _osInputMotusLeg.LegoMotus,
                resFuluidaMotus.RotatioYActualis,
                _configuratioGlobalis.TempusLevigatumRotationis,
                _configuratioGlobalis.LimenInputQuadratum,
                _estLevigatum
            );

            return new OrdinatioMotus(oh, ov, or);
        }

        public IDStatus MutareStatum(IResFuluidaMotusLegibile resFuluidaMotus) {
            if(
                _osInputMotusLeg.LegoMotus.LengthSquared() <= _configuratioGlobalis.LimenInputQuadratum ||
                !_osInputMotusLeg.LegoCursus
            ) {
                return IDStatus.Ambulatio;
            }

            return this.Id;
        }
    }
}