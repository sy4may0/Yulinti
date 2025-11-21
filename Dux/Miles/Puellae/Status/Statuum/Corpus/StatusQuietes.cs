using Yulinti.Dux.ConfigratioDucis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Miles;
using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.Dux.Miles {
    public sealed class StatusQuietes : IStatusCorporis {
        private IDPuellaeAnimationisCorporis _idAnimationis;
        private float _acceleratio;
        private float _deceleratio;
        private bool _estLevigatum;

        private readonly ConfiguratioPuellaeStatuumGlobalis _configuratioGlobalis;

        // DI
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;

        public StatusQuietes(
            ConfiguratioPuellaeStatuumGlobalis configuratioGlobalis,
            ConfiguratioPuellaeStatusQuietes configuratioPuellaeStatusQuietes,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg
        ) {
            _configuratioGlobalis = configuratioGlobalis;
            _idAnimationis = configuratioPuellaeStatusQuietes.IdAnimationis;
            _acceleratio = configuratioPuellaeStatusQuietes.Acceleratio;
            _deceleratio = configuratioPuellaeStatusQuietes.Deceleratio;
            _estLevigatum = configuratioPuellaeStatusQuietes.EstLevigatum;
            _osInputMotusLeg = osInputMotusLeg;
            _osTemporisLeg = osTemporisLeg;
        }

        public IDStatus Id => IDStatus.Quies;
        public IDPuellaeAnimationisCorporis IdAnimationis => _idAnimationis;

        public void Intrare(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public void Exire(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public OrdinatioMotus Ordinare(IResFuluidaMotusLegibile resFuluidaMotus) {
            OrdinatioMotusHorizontalis oh =  OrdinatorMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                0f,
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
            OrdinatioMotusRotationisY or = OrdinatorMotus.OrdinareMotusSineRotationisY(
                resFuluidaMotus.RotatioYActualis
            );
            return new OrdinatioMotus(oh, ov, or);
        }
        public IDStatus MutareStatum(IResFuluidaMotusLegibile resFuluidaMotus) {
            if (_osInputMotusLeg.LegoMotus.LengthSquared() > _configuratioGlobalis.LimenInputQuadratum) {
                return IDStatus.Ambulatio;
            }

            if (_osInputMotusLeg.LegoIncumbo) {
                return IDStatus.Incumbo;
            }

            return this.Id;
        }
    }
}