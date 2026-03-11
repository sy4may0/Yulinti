using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
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
        public IDPuellaeAnimationis IdAnimationisIntrare => _configuratio.IdAnimationisIntrare;
        public IDPuellaeAnimationis IdAnimationisTransere => _configuratio.IdAnimationisTransere;
        public IDPuellaeAnimationis IdAnimationisExire => _configuratio.IdAnimationisExire;

        public bool EstInterdictaIntrare => _configuratio.EstInterdictaIntrare;
        public bool EstInterdictaTransere => _configuratio.EstInterdictaTransere;
        public bool EstInterdictaExire => _configuratio.EstInterdictaExire;

        public IDPuellaeStatusCorporis IdStatusProximusAutomaticus => _configuratio.IdStatusProximusAutomaticus;

        public void Intrare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Corpus,
                IdAnimationisIntrare
            );
        }

        public void Transere(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Corpus,
                IdAnimationisTransere
            );
        }
        
        public void Exire(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Corpus,
                IdAnimationisExire
            );
        }

        public void Ordinare(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            MotusPuellaeHorizontalis oh = InstrumentaPuellaeMotus.OrdinareMotusHorizontalis(
                contextusOstiorum.Introductionis.LegoMotus,
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