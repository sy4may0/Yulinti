using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusPuellaeCorporisMotusLoci : IStatusPuellaeCorporis {
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly IConfiguratioPuellaeStatusCorporisMotus _configuratio;

        public StatusPuellaeCorporisMotusLoci(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporisMotus configuratio
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
        }

        public IDPuellaeStatusCorporis Id => _configuratio.Id;
        public IDPuellaeStatusCorporisModiMotus IdModiMotus => _configuratio.IdModiMotus;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => _configuratio.IdAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => _configuratio.IdAnimationisExire;

        public void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adInitium
        ) {
            _contextusOstiorum.Carrus.ExecutareAnimationis(
                _configuratio.IdAnimationisIntrare,
                adInitium,
                null,
                false
            );
        }
        
        public void Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adFinem
        ) {
            OrdinatioPuellaeAnimationis animationis = new OrdinatioPuellaeAnimationis(
                false, IDPuellaeAnimationisContinuata.None, null, null
            );
            if (_configuratio.LudereExire) {
                _contextusOstiorum.Carrus.ExecutareAnimationis(
                    _configuratio.IdAnimationisExire,
                    null,
                    adFinem,
                    false
                );
            }
        }

        public void Ordinare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            //OrdinatioPuellaeMotusHorizontalis oh = InstrumentaPuellaeMotus.OrdinareMotusHorizontalis(
            //    contextusOstiorum.InputMotus.LegoMotus,
            //    _configuratio.VelocitasDesiderata,
            //    resFluida.Motus.VelocitasActualisHorizontalis,
            //    _configuratio.Acceleratio, _configuratio.Deceleratio,
            //    _configuratioStatuum.TempusLevigatumMin,
            //    _configuratioStatuum.TempusLevigatumMax,
            //    _configuratioStatuum.LimenInputQuadratum,
            //    _configuratio.EstLevigatum
            //);
            //OrdinatioPuellaeMotusVerticalis ov = InstrumentaPuellaeMotus.OrdinareMotusVerticalis(
            //    resFluida.Motus.EstInTerra,
            //    resFluida.Motus.VelocitasActualisVerticalis,
            //    _configuratioStatuum.AcceleratioGravitatis,
            //    _configuratioStatuum.VelocitasContactus,
            //    _configuratioStatuum.VelocitasVerticalisMax,
            //    contextusOstiorum.Temporis.Intervallum
            //);
            //OrdinatioPuellaeMotusRotationisY or = InstrumentaPuellaeMotus.OrdinareMotusRotationisYSecutoria(
            //    contextusOstiorum.Camera.DexterXZ,
            //    contextusOstiorum.Camera.AnteriorXZ,
            //    contextusOstiorum.InputMotus.LegoMotus,
            //    resFluida.Motus.RotatioYActualis,
            //    _configuratioStatuum.TempusLevigatumRotationis,
            //    _configuratioStatuum.LimenInputQuadratum,
            //    _configuratio.EstLevigatum
            //);

            _contextusOstiorum.Carrus.ExecutareMotus(
                0f, // velocitasHorizontalis
                0f, // tempusLevigatumHorizontalis
                0f, // rotatioYDeg
                0f // tempusLevigatumRotationisYDeg
            );
            _contextusOstiorum.Carrus.ExecutareVeletudinis(
                dtVigoris: _configuratio.ConsumptioVigorisSec * contextusOstiorum.Temporis.Intervallum,
                dtPatientiae: _configuratio.ConsumptioPatientiaeSec * contextusOstiorum.Temporis.Intervallum,
                dtAetheris: _configuratio.IncrementumAetherisSec * contextusOstiorum.Temporis.Intervallum,
                dtIntentio: _configuratio.Intentio,
                dtClaritas: _configuratio.Claritas
            );
        }
    }
}
