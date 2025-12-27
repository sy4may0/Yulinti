using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusPuellaeCorporisMotusQuietes : IStatusPuellaeCorporis2 {
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly IConfiguratioPuellaeStatusCorporisMotus _configuratio;
        private readonly IOstiumPuellaeAnimationesMutabile _osAnimationes;

        public StatusPuellaeCorporisMotusQuietes(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporisMotus configuratio,
            IOstiumPuellaeAnimationesMutabile osAnimationes
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
            _osAnimationes = osAnimationes;
        }

        public IDPuellaeStatusCorporis Id => _configuratio.Id;
        public IDPuellaeStatusCorporisModiMotus IdModiMotus => _configuratio.IdModiMotus;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => _configuratio.IdAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => _configuratio.IdAnimationisExire;

        public void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida,
            Action adInitium
        ) {
            _osAnimationes.Postulare(_configuratio.IdAnimationisIntrare, adInitium, null);
        }
        
        public void Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida,
            Action adFinem
        ) {
            if (_configuratio.LudereExire) {
                _osAnimationes.Postulare(_configuratio.IdAnimationisExire, null, adFinem);
            }
        }

        public OrdinatioPuellaeActionis OrdinareActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            OrdinatioPuellaeMotusHorizontalis2 oh = InstrumentaPuellaeMotus2.OrdinareMotusHorizontalis(
                contextusOstiorum.InputMotus.LegoMotus,
                0f,
                contextusResFluida.VelocitasActualisHorizontalis,
                _configuratio.Acceleratio, _configuratio.Deceleratio,
                _configuratioStatuum.TempusLevigatumMin,
                _configuratioStatuum.TempusLevigatumMax,
                _configuratioStatuum.LimenInputQuadratum,
                _configuratio.EstLevigatum
            );
            OrdinatioPuellaeMotusVerticalis2 ov = InstrumentaPuellaeMotus2.OrdinareMotusVerticalis(
                contextusResFluida.EstInTerra,
                contextusResFluida.VelocitasActualisVerticalis,
                _configuratioStatuum.AcceleratioGravitatis,
                _configuratioStatuum.VelocitasContactus,
                _configuratioStatuum.VelocitasVerticalisMax,
                contextusOstiorum.Temporis.Intervallum
            );
            OrdinatioPuellaeMotusRotationisY2 or = InstrumentaPuellaeMotus2.OrdinareMotusSineRotationisY(
                contextusResFluida.RotatioYActualis
            );
            return OrdinatioPuellaeActionis.FromMotus(
                new OrdinatioPuellaeMotus2(oh, ov, or)
            );
        }

        public OrdinatioPuellaeVeletudinis OrdinareVeletudinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return new OrdinatioPuellaeVeletudinis(
                dtVigoris: _configuratio.ConsumptioVigorisSec * contextusOstiorum.Temporis.Intervallum,
                dtPatientiae: _configuratio.ConsumptioPatientiaeSec * contextusOstiorum.Temporis.Intervallum,
                dtAetheris: _configuratio.IncrementumAetherisSec * contextusOstiorum.Temporis.Intervallum,
                dtIntentionis: _configuratio.Intentio
            );

        }
    }
}