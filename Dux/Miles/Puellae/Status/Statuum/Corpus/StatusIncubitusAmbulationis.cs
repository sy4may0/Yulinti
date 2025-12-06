using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Miles;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Miles {
    internal sealed class StatusIncubitusAmbulationis : IStatusCorporis {
        private readonly ThesaurusPuellaeStatuumGlobalis _thesaurusGlobalis;
        private readonly ThesaurusPuellaeStatusIncubitusAmbulationis _thesaurusStatus;

        // DI
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;
        private readonly IOstiumCameraLegibile _osCameraLeg;

        public StatusIncubitusAmbulationis(
            ThesaurusPuellaeStatuumGlobalis thesaurusGlobalis,
            ThesaurusPuellaeStatusIncubitusAmbulationis thesauriPuellaeStatusIncubitusAmbulationem,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg
        ) {
            _thesaurusGlobalis = thesaurusGlobalis;
            _thesaurusStatus = thesauriPuellaeStatusIncubitusAmbulationem;
            _osInputMotusLeg = osInputMotusLeg;
            _osTemporisLeg = osTemporisLeg;
            _osCameraLeg = osCameraLeg;
        }

        public IDStatus Id => IDStatus.IncumboAmbulationem;
        public IDPuellaeAnimationisContinuata IdAnimationis => _thesaurusStatus.IdAnimationis;
        public void Intrare(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public void Exire(IResFuluidaMotusLegibile resFuluidaMotus) {
        }
        public OrdinatioMotus Ordinare(IResFuluidaMotusLegibile resFuluidaMotus) {
            OrdinatioMotusHorizontalis oh =  OrdinatorMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                _thesaurusStatus.VelocitasDesiderata,
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
            OrdinatioMotusRotationisY or = OrdinatorMotus.OrdinareMotusRotationisYSecutoria(
                _osCameraLeg.DexterXZ,
                _osCameraLeg.AnteriorXZ,
                _osInputMotusLeg.LegoMotus,
                resFuluidaMotus.RotatioYActualis,
                _thesaurusGlobalis.TempusLevigatumRotationis,
                _thesaurusGlobalis.LimenInputQuadratum,
                _thesaurusStatus.EstLevigatum
            );

            return new OrdinatioMotus(oh, ov, or);
        }

        public IDStatus MutareStatum(IResFuluidaMotusLegibile resFuluidaMotus) {
            if (
                _osInputMotusLeg.LegoMotus.LengthSquared() <= 
                _thesaurusGlobalis.LimenInputQuadratum
            ) {
                return IDStatus.Incumbo;
            }

            if (!_osInputMotusLeg.LegoIncumbo) {
                return IDStatus.Ambulatio;
            }

            return this.Id;
        }
    }
}
