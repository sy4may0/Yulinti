using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusPuellaeIncubitusAmbulationis : IStatusCorporis {
        private readonly ThesaurusPuellaeStatuum _thesaurus;
        private readonly ThesaurusPuellaeStatusCorporis _thesaurusStatus;
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;
        private readonly IOstiumTemporisLegibile _osTemporisLeg;
        private readonly IOstiumCameraLegibile _osCameraLeg;

        public StatusPuellaeIncubitusAmbulationis(
            IContentumStatusCorporis contentum
        ) {
            _thesaurus = contentum.Thesaurus;
            _thesaurusStatus = contentum.ThesaurusStatus;
            _osInputMotusLeg = contentum.OsInputMotus;
            _osTemporisLeg = contentum.OsTemporis;
            _osCameraLeg = contentum.OsCamera;
        }

        public IDStatus Id => _thesaurusStatus.Id;
        public IDPuellaeAnimationisCorporis IdAnimationis => _thesaurusStatus.IdAnimationis;
        public void Intrare(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
        }
        public void Exire(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
        }
        public OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            OrdinatioPuellaeMotusHorizontalis oh =  OrdinatorPuellaeMotus.OrdinareMotusHorizontalis(
                _osInputMotusLeg.LegoMotus,
                _thesaurusStatus.VelocitasDesiderata,
                resFluidaMotus.VelocitasActualisHorizontalis,
                _thesaurusStatus.Acceleratio, _thesaurusStatus.Deceleratio,
                _thesaurus.TempusLevigatumMin,
                _thesaurus.TempusLevigatumMax,
                _thesaurus.LimenInputQuadratum,
                _thesaurusStatus.EstLevigatum
            );
            OrdinatioPuellaeMotusVerticalis ov =  OrdinatorPuellaeMotus.OrdinareMotusVerticalis(
                resFluidaMotus.EstInTerra,
                resFluidaMotus.VelocitasActualisVerticalis,
                _thesaurus.AcceleratioGravitatis,
                _thesaurus.VelocitasContactus,
                _thesaurus.VelocitasVerticalisMax,
                _osTemporisLeg.Intervallum
            );
            OrdinatioPuellaeMotusRotationisY or = OrdinatorPuellaeMotus.OrdinareMotusRotationisYSecutoria(
                _osCameraLeg.DexterXZ,
                _osCameraLeg.AnteriorXZ,
                _osInputMotusLeg.LegoMotus,
                resFluidaMotus.RotatioYActualis,
                _thesaurus.TempusLevigatumRotationis,
                _thesaurus.LimenInputQuadratum,
                _thesaurusStatus.EstLevigatum
            );

            return new OrdinatioPuellaeMotus(oh, ov, or);
        }
    }
}
