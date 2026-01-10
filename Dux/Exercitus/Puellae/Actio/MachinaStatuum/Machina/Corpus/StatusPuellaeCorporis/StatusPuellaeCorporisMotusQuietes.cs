using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusPuellaeCorporisMotusQuietes : IStatusPuellaeCorporis {
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly IConfiguratioPuellaeStatusCorporisMotus _configuratio;

        public StatusPuellaeCorporisMotusQuietes(
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

        public OrdinatioPuellae Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adInitium
        ) {
            OrdinatioPuellaeAnimationis animationis = new OrdinatioPuellaeAnimationis(
                true, _configuratio.IdAnimationisIntrare, adInitium, null
            );
            return new OrdinatioPuellae(
                animationis: animationis
            );
        }
        
        public OrdinatioPuellae Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adFinem
        ) {
            OrdinatioPuellaeAnimationis animationis = new OrdinatioPuellaeAnimationis(
                false, IDPuellaeAnimationisContinuata.None, null, null
            );
            if (_configuratio.LudereExire) {
                animationis = new OrdinatioPuellaeAnimationis(
                    true, _configuratio.IdAnimationisExire, null, adFinem
                );
            }
            return new OrdinatioPuellae(
                animationis: animationis
            );
        }

        public OrdinatioPuellae Ordinare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            OrdinatioPuellaeMotusHorizontalis oh = InstrumentaPuellaeMotus.OrdinareMotusHorizontalis(
                contextusOstiorum.InputMotus.LegoMotus,
                0f,
                resFluida.Motus.VelocitasActualisHorizontalis,
                _configuratio.Acceleratio, _configuratio.Deceleratio,
                _configuratioStatuum.TempusLevigatumMin,
                _configuratioStatuum.TempusLevigatumMax,
                _configuratioStatuum.LimenInputQuadratum,
                _configuratio.EstLevigatum
            );
            OrdinatioPuellaeMotusVerticalis ov = InstrumentaPuellaeMotus.OrdinareMotusVerticalis(
                resFluida.Motus.EstInTerra,
                resFluida.Motus.VelocitasActualisVerticalis,
                _configuratioStatuum.AcceleratioGravitatis,
                _configuratioStatuum.VelocitasContactus,
                _configuratioStatuum.VelocitasVerticalisMax,
                contextusOstiorum.Temporis.Intervallum
            );
            OrdinatioPuellaeMotusRotationisY or = InstrumentaPuellaeMotus.OrdinareMotusSineRotationisY(
                resFluida.Motus.RotatioYActualis
            );
            OrdinatioPuellaeActionis actionis = OrdinatioPuellaeActionis.FromMotus(
                new OrdinatioPuellaeMotus(oh, ov, or)
            );
            OrdinatioPuellaeVeletudinis veletudinis = new OrdinatioPuellaeVeletudinis(
                dtVigoris: _configuratio.ConsumptioVigorisSec * contextusOstiorum.Temporis.Intervallum,
                dtPatientiae: _configuratio.ConsumptioPatientiaeSec * contextusOstiorum.Temporis.Intervallum,
                dtAetheris: _configuratio.IncrementumAetherisSec * contextusOstiorum.Temporis.Intervallum,
                intentio: _configuratio.Intentio,
                claritas: _configuratio.Claritas
            );
            return new OrdinatioPuellae(
                actionis: actionis, veletudinis: veletudinis
            );
        }
    }
}