using Yulinti.Dux.ContractusDucis;
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

        public void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida,
            Action adInitium
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
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
            if (_configuratio.LudereExire) {
                contextusOstiorum.Carrus.PostulareAnimationis(
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
            MotusPuellaeHorizontalis oh = InstrumentaPuellaeMotus.OrdinareMotusHorizontalis(
                contextusOstiorum.InputMotus.LegoMotus,
                0f,
                resFluida.Motus.VelocitasActualisHorizontalis,
                _configuratio.Acceleratio, _configuratio.Deceleratio,
                _configuratioStatuum.TempusLevigatumMin,
                _configuratioStatuum.TempusLevigatumMax,
                _configuratioStatuum.LimenInputQuadratum,
                _configuratio.EstLevigatum
            );
            MotusPuellaeRotationisY or = InstrumentaPuellaeMotus.OrdinareMotusSineRotationisY(
                resFluida.Motus.RotatioYActualis
            );

            contextusOstiorum.Carrus.PostulareMotus(
                oh.Velocitas,
                oh.TempusLevigatum,
                or.RotatioY,
                or.TempusLevigatum
            );
            contextusOstiorum.Carrus.PostulareVeletudinis(
                dtVigoris: _configuratio.ConsumptioVigorisSec * contextusOstiorum.Temporis.Intervallum,
                dtPatientiae: _configuratio.ConsumptioPatientiaeSec * contextusOstiorum.Temporis.Intervallum,
                dtAetheris: _configuratio.IncrementumAetherisSec * contextusOstiorum.Temporis.Intervallum,
                dtIntentio: _configuratio.Intentio,
                dtClaritas: _configuratio.Claritas,
                dtSonusQuietes: _configuratio.SonusQuietes,
                dtSonusMotus: _configuratio.SonusMotus
            );
        }
    }
}
