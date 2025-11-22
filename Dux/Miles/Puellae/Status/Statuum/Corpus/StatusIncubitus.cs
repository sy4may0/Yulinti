using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Miles;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Miles {
    internal sealed class StatusIncubitus : IStatusCorporis {

        private readonly ThesaurusPuellaeStatuumGlobalis _thesaurusGlobalis;
        private readonly ThesaurusPuellaeStatusIncubitus _thesaurusStatus;

        // DI
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;

        public StatusIncubitus(
            ThesaurusPuellaeStatuumGlobalis thesaurusGlobalis,
            ThesaurusPuellaeStatusIncubitus thesauriPuellaeStatusIncubitus,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg
        ) {
            _thesaurusGlobalis = thesaurusGlobalis;
            _thesaurusStatus = thesauriPuellaeStatusIncubitus;
            _osInputMotusLeg = osInputMotusLeg;
            _osTemporisLeg = osTemporisLeg;
        }

        public IDStatus Id => IDStatus.Incumbo;
        public IDPuellaeAnimationisCorporis IdAnimationis => _thesaurusStatus.IdAnimationis;

        public void Intrare(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public void Exire(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public OrdinatioMotus Ordinare(IResFuluidaMotusLegibile resFuluidaMotus) {
            OrdinatioMotusHorizontalis oh =  OrdinatorMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                0f,
                resFuluidaMotus.VelocitasActualisHorizontal,
                _thesaurusStatus.Acceleratio, _thesaurusStatus.Deceleratio,
                _thesaurusGlobalis.TempusLevigatumMin,
                _thesaurusGlobalis.TempusLevigatumMax,
                _thesaurusGlobalis.LimenInputQuadratum,
                _thesaurusStatus.EstLevigatum
            );
            OrdinatioMotusVerticalis ov =  OrdinatorMotus.OrdinareMotusVerticalis(
                resFuluidaMotus.EstInTerra,
                resFuluidaMotus.VelocitasActualisVertical,
                _thesaurusGlobalis.AcceleratioGravitatis,
                _thesaurusGlobalis.VelocitasContactus,
                _thesaurusGlobalis.VelocitasVerticalisMax,
                _osTemporisLeg.Intervallum
            );
            OrdinatioMotusRotationisY or = OrdinatorMotus.OrdinareMotusSineRotationisY(
                resFuluidaMotus.RotatioYActualis
            );
            return new OrdinatioMotus(oh, ov, or);
        }
        public IDStatus MutareStatum(IResFuluidaMotusLegibile resFuluidaMotus) {
            if (
                _osInputMotusLeg.LegoMotus.LengthSquared() > 
                _thesaurusGlobalis.LimenInputQuadratum
            ) {
                return IDStatus.IncumboAmbulationem;
            }

            if (!_osInputMotusLeg.LegoIncumbo) {
                return IDStatus.Quies;
            }

            return this.Id;
        }
    }
}
